const {app} = require("electron").remote,
    {spawn} = require("child_process"),
    moment = require("moment");

/** Runs FFmpeg to transcode an output. */
class FFmpeg {
    /**
     * Initialises an instance of FFmpeg.
     * @param {File} input - The input file.
     * @param {int} outputIndex - The output index to use.
     */
    constructor(input, outputIndex) {
        // Initialise input file path and encoding settings
        this.input = input;
        this.settings = input.outputs[outputIndex];
        // Initialise event listeners
        this.listeners = new Map();
        // Initialise encoding progress information
        this.duration;
        this.progressPercentage = 0;
        this.progressStatus = "";
    }

    /**
     * Starts the transcode.
     */
    start() {
        // Build the command to run
        let args = [];
        args = this.buildInputArgs().concat(this.buildEncodingArgs(), ["-hide_banner", "-y", this.settings.path]);
        // Start encoding process
        let process = spawn(path.join(app.getAppPath(), "../", "bin", "ffmpeg"), args, {
            windowsHide: true
        });
        // Fire finished event when FFmpeg closes
        process.on("close", () => {
            this.fireEvent("finished");
        });
        // Process FFmpeg output
        process.stderr.on("data", this.processOutput.bind(this));
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
            args.push("mpeg2video");
        }
        // If the input contains audio, set the audio encoder
        if (this.input.audioStreams.length > 0) {
            args.push("-c:a");
            args.push("aac");
        }
        // Return arguments
        return args;
    }

    /**
     * Processes the output from the FFmpeg encode.
     * @param {stream.Readable} data - The line of data outputted by FFmpeg.
     */
    processOutput(data) {
        // Convert output stream to text
        let output = data.toString();
        // Log output for debugging
        console.info("[FFmpeg] " + output);
        // Process output from FFmpeg depending on what the output is
        if (output.startsWith("Input")) { // Output contains input information
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
            // If a duration has been set, calculate progress percentage
            if (typeof this.duration !== "undefined") {
                // Locate the timecode in the progress information
                let timeIndex = output.indexOf("time");
                // Increase time index to the start of the timecode
                timeIndex += 5;
                // Locate the space following the duration
                let spaceIndex = output.indexOf(" ", timeIndex);
                // Retrieve current timecode
                let timecode = moment.duration(output.slice(timeIndex, spaceIndex));
                // Convert times to seconds and calculate percentage encoded
                this.progressPercentage = Math.round((100 / this.duration.asSeconds()) * timecode.asSeconds());
            }
            // Update the progress status with the output
            this.progressStatus = output;
            // Fire progress changed event
            this.fireEvent("progressChanged");
        }
    }

    /**
     * Add an event listener callback to an event channel.
     * @param {string} channel - The name of the channel to listen to.
     * @param {function} callback - A callback method to run when the event channel is fired.
     */
    addListener(channel, callback) {
        // Create the event channel with an empty array of callbacks if it doesn't exist
        if (!this.listeners.has(channel)) {
            this.listeners.set(channel, []);
        }
        // Add the callback to the event channel array
        this.listeners.get(channel).push(callback);
    }

    /**
     * Removes an event listener callback from an event channel.
     * @param {string} channel - The name of the channel to remove the listener from.
     * @param {function} callback - The callback method to be removed from the event channel.
     * @returns {boolean} True if successfully removed, false otherwise.
     */
    removeListener(channel, callback) {
        // Get listener callbacks for the channel, and initialise the index
        let listeners = this.listeners.get(channel);
        let index;
        // If there are listeners for the channel, check for the callback and remove it
        if (typeof listeners !== "undefined" && listeners.length > 0) {
            // Determine the index of the callback to be removed
            index = listeners.reduce((i, listener, index) => {
                return (typeof listener == "function" && listener === callback) ? i = index : i;
            }, -1);
            // If an index is returned, remove it from the array of callbacks
            if (index > -1) {
                listeners.splice(index, 1);
                this.listeners.set(channel, listeners);
                // Return tue to indicate the listener was successfully removed
                return true;
            }
        }
        // Return false if unable to remove the callback
        return false;
    }

    /**
     * Fires an event channel.
     * @param {string} channel - The name of the event channel to fire.
     */
    fireEvent(channel) {
        // Get the event listeners for the channel
        let listeners = this.listeners.get(channel);
        // If there are listeners, call each one
        if (typeof listeners !== "undefined" && listeners.length > 0) {
            listeners.forEach((listener) => {
                listener(); 
            });
        }
    }
}

module.exports.FFmpeg = FFmpeg;