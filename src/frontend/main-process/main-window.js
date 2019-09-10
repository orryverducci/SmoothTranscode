import {BrowserWindow, ipcMain} from "electron";

/** The main window for the application. */
export class MainWindow {
    /**
     * The window.
     *
     * @type {BrowserWindow}
     */
    _window = null;

    /**
     * Initialises an instance of MainWindow.
     */
    constructor() {
        // Create the window
        this._window = new BrowserWindow({
            width: 800,
            height: 600,
            show: false,
            webPreferences: {
                nodeIntegration: true
            }
        });
        // Load the main window
        this._window.loadURL("app://smoothtranscode/main-window.html");
        // Destroy reference to the window when it is closed
        this._window.on("closed", () => {
            this._window = null;
        });
        // Show the main window when the ready event has been received from the renderer process
        ipcMain.on("ready", () => {
            this._window.show();
        });
    }
}