import {app} from "electron";
import {spawn} from "child_process";
import fs from "fs";
import path from "path";
import moment from "moment";
import makeEta from "simple-eta";
import {EventClass} from "./event-class.js";

/** Runs FFmpeg to transcode an output. */
export class FFmpeg extends EventClass {
    /**
     * Initialises an instance of FFmpeg.
     * @param {File} input - The input file.
     * @param {int} outputIndex - The output index to use.
     */
    constructor(input, outputIndex) {
        super();
        // Initialise input file path and encoding settings
        this.input = input;
        this.output = input.outputs[outputIndex];
        // Initialise encoding process
        this.running = false;
        this.process;
        // Initialise encoding progress information
        this.duration;
        this.progressTime = "00:00:00";
        this.progressBitrate = "0kbits/s";
        this.progressSpeed = "0x";
        this.progressPercentage = 0;
        this.lastStatus = "";
        this.eta = makeEta({min: 0, max: 100});
    }

    /**
     * Starts the transcode.
     */
    start() {
        // Build the command to run
        let args = [];
        args = this.buildInputArgs().concat(this.buildEncodingArgs(), ["-hide_banner", "-y", this.output.path]);
        // Mark the process as running
        this.running = true;
        // Start encoding process
        this.process = spawn(path.join(app.getAppPath(), "..", "..", "bin", "ffmpeg"), args, {
            windowsHide: true
        });
        // Fire finished event and mark as not running when FFmpeg closes
        this.process.on("close", this.encodeFinished.bind(this));
        // Process FFmpeg output
        this.process.stderr.on("data", this.processOutput.bind(this));
        // Start calculating ETA
        this.eta.start();
    }

    /**
     * Stops the transcode.
     */
    stop() {
        // Stop transcoding if the process is currently running
        if (this.running) {
            // Mark encode as not running
            this.running = false;
            // Kill the FFmpeg process
            this.process.kill();
            // Delete the partially transcoded file
            fs.unlinkSync(this.output.path);
        }
    }

    /**
     * Builds the arguments to set the input file and options.
     * @returns {Array.<string>} Returns an array of arguments in the correct order.
     */
    buildInputArgs() {
        let args = [];
        // Set input file
        args.push("-i");
        args.push(this.input.path);
        // Return arguments
        return args;
    }

    /**
     * Builds the arguments to set the encoding options.
     * @returns {Array.<string>} Returns an array of arguments in the correct order.
     */
    buildEncodingArgs() {
        let args = [];
        // If the input contains video, set the video encoder
        if (this.input.videoStreams.length > 0) {
            args.push("-c:v");
            args.push(this.output.settings.videoCodec);
        }
        // If the input contains audio, set the audio encoder
        if (this.input.audioStreams.length > 0) {
            args.push("-c:a");
            args.push(this.output.settings.audioCodec);
        }
        // Return arguments
        return args;
    }

    /**
     * Processes the output from the FFmpeg encode.
     * @param {stream.Readable} data - The line of data outputted by FFmpeg.
     */
    processOutput(data) {
        // Convert output stream to text and set as last status message received
        let output = data.toString();
        this.lastStatus = output;
        // Process output and update progress if the encode is running
        if (this.running) {
            // Process output from FFmpeg depending on what the output is
            if (output.includes("Input #0")) { // Output contains input information
                // Locate the duration in the input information
                let durationIndex = output.indexOf("Duration:");
                // If the duration is found, retrieve it
                if (durationIndex !== -1) {
                    // Increase duration index to start of duration time
                    durationIndex += 10;
                    // Locate the comma following the duration
                    let commaIndex = output.indexOf(",", durationIndex);
                    // Retrieve duration time
                    this.duration = moment.duration(output.slice(durationIndex, commaIndex));
                }
            } else if (output.startsWith("frame=") || output.startsWith("size=")) { // Output contains encoding progress
                // Create a map of status properties
                let status = new Map();
                // Remove spaces in output following a '=' character
                output = output.replace(/=( *)/g, "=");
                // Split output line into segments split by spaces
                let outputSegments = output.split(" ");
                // Split each segment into key and value, and add to the map of statush properties
                outputSegments.forEach((segment) => {
                    let segmentValues = segment.split("=");
                    status.set(segmentValues[0], segmentValues[1]);
                });
                // Update time encoded
                this.progressTime = status.get("time").substring(0, status.get("time").length - 3);
                // If a duration has been set, calculate progress percentage and update eta
                if (typeof this.duration !== "undefined") {
                    // Retrieve current timecode
                    let timecode = moment.duration(this.progressTime);
                    // Convert times to seconds and calculate percentage encoded
                    let percentage = (100 / this.duration.asSeconds()) * timecode.asSeconds();
                    this.eta.report(percentage);
                    this.progressPercentage = Math.round(percentage);
                }
                // Update encoding bitrate
                this.progressBitrate = status.get("bitrate");
                // Update encoding speed
                this.progressSpeed = status.get("speed");
                // Fire update event
                super.fireEvent("status-updated");
            }
        }
    }

    /**
     * Handles the completion of an encode.
     * @param {int} code - The exit code returned by FFmpeg.
     * @param {string} signal - The signal that was used to terminate FFmpeg.
     */
    encodeFinished(code, signal) {
        if (this.running) {
            // Set that the encode is no longer running
            this.running = false;
            // If the exit code is not 0, set that there was an error and delete the partially transcoded file, otherwise set the status to complete
            if (code !== 0) {
                this.output.status = "error";
                this.output.errorMessage = this.lastStatus;
                fs.unlinkSync(this.output.path);
            } else {
                this.output.status = "complete";
            }
            // Fire the finished event
            super.fireEvent("finished");
        }
    }
}