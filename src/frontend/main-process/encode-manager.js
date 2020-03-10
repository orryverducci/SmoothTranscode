import {ipcMain, IpcMessageEvent, Notification} from "electron";
import _ from "lodash";
import humanizeDuration from "humanize-duration";
import {SourceFile} from "./source-file.js";
import {FFmpeg} from "./ffmpeg.js";

/** Manages the files to be encoded. */
export class EncodeManager {
    /**
     * The queue of source files and the encode jobs.
     *
     * @type {Array.<SourceFile>}
     */
    _queue = [];

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
        ipcMain.on("add-source", this.addSource.bind(this));
        ipcMain.on("remove-file", this.removeSource.bind(this));
        ipcMain.on("add-output", this.addOutput.bind(this));
        ipcMain.on("remove-output", this.removeOutput.bind(this));
        ipcMain.on("change-output-path", this.changeOutputPath.bind(this));
        ipcMain.on("start-encoding", this.startEncoding.bind(this));
        ipcMain.on("stop-encoding", this.stopEncoding.bind(this));
    }

    /**
     * Adds a source file to the queue.
     *
     * @param {IpcMessageEvent} event - The IPC event.
     * @param {string} filePath - The path to the file to be added.
     */
    addSource(event, filePath) {
        // Check if the file has already been added, and ignore it if it has
        if (_.find(this._queue, {path: filePath})) {
            return;
        }
        // Create the source
        let source = new SourceFile(filePath);
        // If the source is a valid media file, add it to the queue, otherwise return an error
        if (!source.error) {
            this._queue.push(source);
            event.reply("update-queue", JSON.stringify(this._queue));
        } else {
            event.reply("add-source-error");
        }
    }

    /**
     * Removes a source file from the queue.
     *
     * @param {IpcMessageEvent} event - The IPC event.
     * @param {number} sourceID - The ID of the source to remove.
     */
    removeSource(event, sourceID) {
        // Find the source to remove
        let source = _.find(this._queue, {id: sourceID});
        // If a source with the given ID can't be found, return the method
        if (typeof source === "undefined") {
            return;
        }
        // Remove the source from the queue
        this._queue.splice(this._queue.indexOf(source), 1);
        event.reply("update-queue", JSON.stringify(this._queue));
    }

    /**
     * Adds an output to a source.
     *
     * @param {IpcMessageEvent} event - The IPC event.
     * @param {number} sourceID - The ID of the source to add an output to.
     */
    addOutput(event, sourceID) {
        // Find the source to add an output to
        let source = _.find(this._queue, {id: sourceID});
        // If a source with the given ID can't be found, return the method
        if (typeof source === "undefined") {
            return;
        }
        // Add an output to the file
        source.addOutput();
        event.reply("update-queue", JSON.stringify(this._queue));
    }

    /**
     * Removes an output from a file.
     *
     * @param {IpcMessageEvent} event - The IPC event.
     * @param {number} sourceID - The ID of the source to remove an output from.
     * @param {number} outputID - The ID of the output to remove.
     */
    removeOutput(event, sourceID, outputID) {
        // Find the source to remove an output from
        let source = _.find(this._queue, {id: sourceID});
        // If a source with the given ID can't be found, return the method
        if (typeof source === "undefined") {
            return;
        }
        // Add an output to the file
        source.removeOutput(outputID);
        event.reply("update-queue", JSON.stringify(this._queue));
    }

    /**
     * Changes the file path of an output.
     *
     * @param {IpcMessageEvent} event - The IPC event.
     * @param {number} sourceID - The ID of the source containing the output to be changed.
     * @param {number} outputID - The ID of the output to change.
     * @param {string} filePath - The output file path.
     */
    changeOutputPath(event, sourceID, outputID, filePath) {
        // Find the file containing the output to be changed
        let source = _.find(this._queue, {id: sourceID});
        // If a source with the given ID can't be found, return the method
        if (typeof source === "undefined") {
            return;
        }
        // Find the output to change
        let output = _.find(source.outputs, {id: outputID});
        // If an output with the given ID can't be found, return the method
        if (typeof output === "undefined") {
            return;
        }
        // Change the file path for the output
        output.path = filePath;
        event.reply("update-queue", JSON.stringify(this._queue));
    }

    /**
     * Starts encoding the queue.
     *
     * @param {IpcMessageEvent} event - The IPC event.
     */
    startEncoding(event) {
        if (this._encoding) {
            return;
        }
        for (let i = 0; i < this._queue.length; i++) {
            for (let x = 0; x < this._queue[i].outputs.length; x++) {
                if (this._queue[i].outputs[x].status === "pending") {
                    let encode = new FFmpeg(this._queue[i], x);
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
        this._ipcEvent.reply("update-queue", JSON.stringify(this._queue));
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