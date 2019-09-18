import {app, dialog, protocol} from "electron";
import installExtension, {VUEJS_DEVTOOLS} from "electron-devtools-installer";
import {createReadStream, existsSync as fileExists} from "fs";
import path from "path";
import {URL} from "url";
import jsonfile from "jsonfile";
import {EncodeManager} from "./encode-manager.js";
import {MainWindow} from "./main-window.js";

// Global references for the main window and the file manager, preventing them from being garbage collected
let mainWindow = null, // eslint-disable-line no-unused-vars
    encodeManager = new EncodeManager(); // eslint-disable-line no-unused-vars

// Register the 'app' protocol as a standard stream
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
 * Handles requests to the 'app' protocol.
 *
 * @param {object} request - The request from the renderer.
 * @param {Function} callback - The callback to return the content requested.
 */
function appProtocolHandler(request, callback) {
    // Get path name from url
    let pathName = new URL(request.url).pathname;
    // Create path to the file to return
    let filePath = path.join(__dirname, "..", "ui", pathName);
    // Determine the appropriate MIME type for the file
    let fileExtension = path.extname(filePath).substr(1);
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
}

// Disable navigation in windows
app.on("web-contents-created", (e, contents) => {
    contents.on("will-navigate", (event) => {
        event.preventDefault();
    });
});

// Initialise the application when Electron is ready
app.on("ready", () => {
    // Create the 'app' protocol used by the application to load UI pages
    protocol.registerStreamProtocol("app", appProtocolHandler, (error) => {
        if (error) {
            dialog.showErrorBox("Failed to register protocol", "SmoothTranscode was unable to start as it can't create the user interface.");
            app.quit();
        }
    });
    // Add Vue Devtools to Chrome developer tools
    installExtension(VUEJS_DEVTOOLS).catch((error) => {
        console.log(`Unable to add Vue Devtools: ${error}`);
    });
    // Creates the main application window
    mainWindow = new MainWindow();
});

// Quit the application when all windows are closed
app.on("window-all-closed", () => {
    app.quit();
});