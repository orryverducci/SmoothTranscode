import path from "path";
import _ from "lodash";
import {StreamInfo} from "./stream-info.js";
import {Output} from "./output.js";

/** Provides information and transcode settings for a media file. */
export class SourceFile {
    /**
     * The unique ID of the source file.
     *
     * @type {string}
     */
    id = "";

    /**
     * The file path of the source file.
     *
     * @type {string}
     */
    path = "";

    /**
     * If there was an error reading the source file.
     *
     * @type {boolean}
     */
    error = false;

    /**
     * The name of the source file.
     *
     * @type {string}
     */
    name = "";

    /**
     * Information about the media streams in the source file.
     *
     * @type {StreamInfo}
     */
    streamInfo = null;

    /**
     * The outputs to be encoded from this source file.
     *
     * @type {Array.<Output>}
     */
    outputs = [];

    /**
     * The suffix number to be added to the default path when an output is created.
     * 
     * @type {number}
     */
    newOutputSuffix = 1;

    /**
     * Initialises an instance of SourceFile.
     *
     * @param {string} filePath - The path to the file.
     */
    constructor(filePath) {
        // Set the file path
        this.path = filePath;
        this.name = this.path.substring(this.path.lastIndexOf(path.sep) + 1);
        // Generate unique ID, based on timestamp plus a random number
        this.id = Date.now() + Math.round(Math.random() * 10e5);
        // Get information about the media streams in the file
        this.streamInfo = new StreamInfo(filePath);
        // If streams are found, add an output, otherwise mark that there was an error reading the file
        if (this.streamInfo.videoStreams.length > 0 || this.streamInfo.audioStreams.length > 0) {
            this.addOutput();
        } else {
            this.error = true;
        }
    }

    /**
     * Add a new transcode output to the file.
     */
    addOutput() {
        // Create new default file path for the output
        let filePath = `${this.path.substring(0, this.path.lastIndexOf("."))}_${this.newOutputSuffix}${this.path.substring(this.path.lastIndexOf("."))}`;
        // Add a new output to be encoded
        this.outputs.push(new Output(filePath));
        // Increase the default path suffix number
        this.newOutputSuffix++;
    }

    /**
     * Removes a transcode output from the file
     *
     * @param {number} outputID - The ID of the output to remove.
     */
    removeOutput(outputID) {
        // Find the output to remove
        let output = _.find(this.outputs, {id: outputID});
        // If an output with the given ID can't be found, return the method
        if (typeof output === "undefined") {
            return;
        }
        // Remove the output
        this.outputs.splice(this.outputs.indexOf(output), 1);
    }
}