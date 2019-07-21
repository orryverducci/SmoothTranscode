import { app, BrowserWindow, protocol } from "electron";
import installExtension, { VUEJS_DEVTOOLS } from "electron-devtools-installer";
import { createReadStream, existsSync as fileExists } from "fs";
import path from "path";
import { URL } from "url";
import jsonfile from "jsonfile";

// Global reference for the main window, preventing it from being garbage collected
let mainWindow = null;

// Set app path to the application's root folder
app.setAppPath(__dirname);

// Register the app protocol as a standard stream
protocol.registerSchemesAsPrivileged([
    {
        scheme: "app",
        privileges: {
            standard: true,
            secure: true
        }
    }
]);

/**
 * Creates a standard scheme for use by the application
 */
function createAppProtocol() {
    // Create the app protocol
    protocol.registerStreamProtocol("app", (request, callback) => {
        // Get path name from url
        let pathName = new URL(request.url).pathname;
        // Create path to the file to return
        let filePath = path.join(__dirname, pathName);
        // Get the file extension
        let fileExtension = path.extname(filePath).substr(1);
        // Determine the appropriate MIME type for the file
        let fileMimeType = "application/octet-stream";
        let mimeTypes = jsonfile.readFileSync(path.join(__dirname, "mimetypes.json"));
        if (typeof mimeTypes[fileExtension] !== "undefined") {
            fileMimeType = mimeTypes[fileExtension];
        }
        // Check the file exists and get the file's stream if it does
        let statusCode, fileStream;
        if (fileExists(filePath)) {
            statusCode = 200;
            fileStream = createReadStream(filePath);
        } else {
            statusCode = 404;
        }
        // Return the file contents with the appropriate mime type
        callback({
            statusCode: statusCode,
            headers: {
                "Content-Type": fileMimeType,
                "Content-Security-Policy": "default-src app:; script-src 'unsafe-inline'"
            },
            data: fileStream
        });
    }, (error) => {
        if (error) {
            console.error("Failed to register app protocol");
        }
    });
}

/**
 * Creates the main application window
 */
function createMainWindow() {
    // Create the main window
    mainWindow = new BrowserWindow({
        width: 800,
        height: 600,
        show: false,
        webPreferences: {
            nodeIntegration: true
        }
    });
    // Load the main window
    mainWindow.loadURL("app://smoothtranscode/main-window.html");
    // Show the window when the page has been rendered
    mainWindow.once("ready-to-show", () => {
        mainWindow.show()
    })
    // Destroy reference to the main window when it is closed
    mainWindow.on("closed", () => {
        mainWindow = null;
    });
}

/**
 * Setup Chrome developer tools
 */
function setupDevTools() {
    // Add Vue Devtools
    installExtension(VUEJS_DEVTOOLS).catch((error) => {
        console.log(`Unable to add Vue Devtools: ${error}`);
    });
}

// Disable navigation in windows
app.on("web-contents-created", (event, contents) => {
    contents.on("will-navigate", (event, navigationUrl) => {
        event.preventDefault();
    })
});

// Create the main window when Electron has finished initialisation
app.on("ready", () => {
    createAppProtocol();
    setupDevTools();
    createMainWindow();
});

// Quit the application when all windows are closed
app.on("window-all-closed", () => {
    app.quit();
});