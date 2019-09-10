import {ipcMain, IpcMessageEvent, Notification} from "electron";
import _ from "lodash";
import humanizeDuration from "humanize-duration";
import {File} from "./file";
import {FFmpeg} from "./ffmpeg";

/** Manages the files to be encoded. */
export class EncodeManager {
    /**
     * The files to be encoded.
     *
     * @type {Array.<File>}
     */
    files = [];

    /**
     * Represents if encodes are currently running.
     *
     * @type {boolean}
     */
    _encoding = false;

    /**
     * The IPC event used for encode status replies.
     *
     * @type {IpcMessageEvent}
     */
    _ipcEvent = null;

    /**
     * The currently running encodes.
     *
     * @type {Array.<FFmpeg>}
     */
    _encodes = [];

    /**
     * The index of the current encode.
     *
     * @type {number}
     */
    _currentEncode = -1;

    /**
     * Initialises an instance of EncodeManager.
     */
    constructor() {
        // Add event listeners
        ipcMain.on("add-file", this.addFile.bind(this));
        ipcMain.on("remove-file", this.removeFile.bind(this));
        ipcMain.on("add-output", this.addOutput.bind(this));
        ipcMain.on("remove-output", this.removeOutput.bind(this));
        ipcMain.on("change-output-path", this.changeOutputPath.bind(this));
        ipcMain.on("start-encoding", this.startEncoding.bind(this));
        ipcMain.on("stop-encoding", this.stopEncoding.bind(this));
    }

    /**
     * Adds a file to be encoded.
     *
     * @param {IpcMessageEvent} event - The IPC event.
     * @param {string} filePath - The path to the file to be added.
     */
    addFile(event, filePath) {
        // Check if the file has already been added, and ignore it if it has
        if (_.find(this.files, {path: filePath})) {
            return;
        }
        // Create the file
        let file = new File(filePath);
        // If the file is a valid media file, add it to the list of files, otherwise return an error
        if (!file.error) {
            this.files.push(file);
            this.addOutput(null, file.id);
            event.reply("update-files", JSON.stringify(this.files));
        } else {
            event.reply("add-file-error");
        }
    }

    /**
     * Removes a file from the list of files to be encoded.
     *
     * @param {IpcMessageEvent} event - The IPC event.
     * @param {number} fileID - The ID of the file to remove.
     */
    removeFile(event, fileID) {
        // Find the file to remove
        let file = _.find(this.files, {id: fileID});
        // If a file with the given ID can't be found, return the method
        if (typeof file === "undefined") {
            return;
        }
        // Remove the file
        this.files.splice(this.files.indexOf(file), 1);
        // Send a reply to the frontend to update files
        event.reply("update-files", JSON.stringify(this.files));
    }

    /**
     * Adds an output to a file.
     *
     * @param {IpcMessageEvent} event - The IPC event.
     * @param {number} fileID - The ID of the file to add an output to.
     */
    addOutput(event, fileID) {
        // Find the file to add an output to
        let file = _.find(this.files, {id: fileID});
        // If a file with the given ID can't be found, return the method
        if (typeof file === "undefined") {
            return;
        }
        // Add an output to the file
        file.addOutput();
        // If an IPC event has been provided, send a reply to the frontend to update files
        if (event !== null) {
            event.reply("update-files", JSON.stringify(this.files));
        }
    }

    /**
     * Removes an output from a file.
     *
     * @param {IpcMessageEvent} event - The IPC event.
     * @param {number} fileID - The ID of the file to remove an output from.
     * @param {number} outputID - The ID of the output to remove.
     */
    removeOutput(event, fileID, outputID) {
        // Find the file to remove an output from
        let file = _.find(this.files, {id: fileID});
        // If a file with the given ID can't be found, return the method
        if (typeof file === "undefined") {
            return;
        }
        // Add an output to the file
        file.removeOutput(outputID);
        // Send a reply to the frontend to update files
        event.reply("update-files", JSON.stringify(this.files));
    }

    /**
     * Changes the file path of an output.
     *
     * @param {IpcMessageEvent} event - The IPC event.
     * @param {number} fileID - The ID of the file containing the output to be changed.
     * @param {number} outputID - The ID of the output to change.
     * @param {string} filePath - The output file path.
     */
    changeOutputPath(event, fileID, outputID, filePath) {
        // Find the file containing the output to be changed
        let file = _.find(this.files, {id: fileID});
        // If a file with the given ID can't be found, return the method
        if (typeof file === "undefined") {
            return;
        }
        // Find the output to change
        let output = _.find(file.outputs, {id: outputID});
        // If an output with the given ID can't be found, return the method
        if (typeof file === "undefined") {
            return;
        }
        // Change the file path for the output
        output.path = filePath;
        // Send a reply to the frontend to update files
        event.reply("update-files", JSON.stringify(this.files));
    }

    /**
     * Starts encoding the files.
     *
     * @param {IpcMessageEvent} event - The IPC event.
     */
    startEncoding(event) {
        if (this._encoding) {
            return;
        }
        for (let i = 0; i < this.files.length; i++) {
            for (let x = 0; x < this.files[i].outputs.length; x++) {
                if (this.files[i].outputs[x].status === "pending") {
                    let encode = new FFmpeg(this.files[i], x);
                    this._encodes.push(encode);
                }
            }
        }
        this._encoding = true;
        this._ipcEvent = event;
        this.startNextFile();
    }

    /**
     * Starts the next encode in the queue.
     */
    startNextFile() {
        this._currentEncode++;
        this._ipcEvent.reply("update-files", JSON.stringify(this.files));
        if (this._currentEncode < this._encodes.length) {
            this._encodes[this._currentEncode].addListener("status-updated", this.sendEncodingStatus.bind(this));
            this._encodes[this._currentEncode].addListener("finished", this.startNextFile.bind(this));
            this._encodes[this._currentEncode].start();
        } else {
            this._encoding = false;
            this._encodes.length = 0;
            this._currentEncode = -1;
            let notification = new Notification({
                title: "SmoothTranscode",
                body: "Media conversions finished"
            });
            notification.show();
        }
        this.sendEncodingStatus();
    }

    /**
     * Stops the currently running encodes.
     */
    stopEncoding() {
        if (!this._encoding) {
            return;
        }
        this._encodes[this._currentEncode].stop();
        this._encoding = false;
        this._encodes.length = 0;
        this._currentEncode = -1;
        this.sendEncodingStatus();
    }

    /**
     * Sends the current encoding status to the frontend.
     */
    sendEncodingStatus() {
        let percentage = this._encoding ? Math.round(((100 * this._currentEncode) + this._encodes[this._currentEncode].progressPercentage) / this._encodes.length) : -1;
        let time = this._encoding ? this._encodes[this._currentEncode].progressTime : "00:00:00";
        let bitrate = this._encoding ? this._encodes[this._currentEncode].progressBitrate : "0kbits/s";
        let speed = this._encoding ? this._encodes[this._currentEncode].progressSpeed : "0x";
        let eta = this._encoding ? humanizeDuration(this._encodes[this._currentEncode].eta.estimate() * 1000, {round: true}) : "0 seconds";
        this._ipcEvent.reply("encode-status-update", {
            encoding: this._encoding,
            percentage: percentage,
            currentEncode: this._currentEncode + 1,
            totalEncodes: this._encodes.length,
            time: time,
            bitrate: bitrate,
            speed: speed,
            eta: eta
        });
        if (!this._encoding) {
            this._ipcEvent = null;
        }
    }
}