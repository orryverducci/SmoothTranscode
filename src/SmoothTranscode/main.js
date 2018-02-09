const {app, BrowserWindow, dialog} = require("electron"),
    path = require("path"),
    url = require("url");

// Global reference for the main window, preventing it from being garbage collected
let mainWindow;

// Set app path to the application's root folder
app.setAppPath(__dirname);

function createMainWindow() {
    // Create the main window
    mainWindow = new BrowserWindow({
        width: 800,
        height: 600
    });
    // Load the main window
    mainWindow.loadURL(url.format({
        pathname: path.join(__dirname, "main-window", "index.html"),
        protocol: "file:",
        slashes: true
    }));
    // Destroy reference to the main window when it is closed
    mainWindow.on("closed", () => {
        mainWindow = null;
    });
}

// Create the main window when Electron has finished initialization
app.on("ready", createMainWindow);

// Quit the application when all windows are closed
app.on("window-all-closed", () => {
    app.quit();
});