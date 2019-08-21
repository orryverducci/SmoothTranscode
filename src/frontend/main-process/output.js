import { app } from "electron";
import { Settings } from "./settings.js";

const jsonfile = require("jsonfile"),
    path = require("path");

/** Provides information and transcode settings for an individual transcode output. */
export class Output {
    /**
     * Initialises an instance of Output.
     * @param {string} filePath - The initial path to the output file.
     */
    constructor(filePath) {
        // Set the initial file path
        this.path = filePath;
        // Generate unique ID, based on timestamp plus a random number
        this.id = Date.now() + Math.round(Math.random() * 10e5);
        // Set initial status
        this.status = "pending";
        // Set error message to a blank string
        this.errorMessage = "";
        // Initialise encode settings with defaults
        this.settings = new Settings();
        // Set file extension to the container default
        this.ChangeExtension();
    }

    ChangeExtension() {
        // Load list of available containers and their extensions
        let containers = jsonfile.readFileSync(path.join(app.getAppPath(), "containers.json"));
        // Find object containing the container information
        let containerInfo = containers[this.settings.container];
        // If the container info was found, find the extension for the container, and set it
        if (typeof containerInfo !== "undefined") {
            // Find default extension for chosen container
            let extension = containerInfo.extensions[0];
            // Change the extension of the file path
            this.path = this.path.substring(0, this.path.lastIndexOf(".")) + "." + extension;
        }
    }
}