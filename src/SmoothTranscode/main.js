const {app, BrowserWindow, dialog} = require("electron"),
    {default: installExtension, VUEJS_DEVTOOLS} = require("electron-devtools-installer"),
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

function setupDevTools() {
    // Add Vue Devtools
    installExtension(VUEJS_DEVTOOLS).catch((error) => {
        console.log("Error occurred adding Vue Devtools: ", error);
    });
}

// Create the main window when Electron has finished initialization
app.on("ready", () => {
    setupDevTools();
    createMainWindow();
});

// Quit the application when all windows are closed
app.on("window-all-closed", () => {
    app.quit();
});