const {app} = require("electron").remote,
    exec = require("child_process").execFileSync,
    path = require("path"),
    {Output} = require("./output");

/** Provides information and transcode settings for a media file. */
class File {
    /**
     * Initialises an instance of File.
     * @param {string} filePath - The path to the file.
     */
    constructor(filePath) {
        // Initialise properties
        this.error = false;
        this.videoStreams = [];
        this.audioStreams = [];
        this.outputs = [];
        this.newOutputSuffix = 1;
        // Set the file path
        this.path = filePath;
        this.name = this.path.substring(this.path.lastIndexOf(path.sep) + 1);
        // Generate unique ID, based on timestamp plus a random number
        this.id = Date.now() + Math.round(Math.random() * 10e5);
        // Retrieve information about the file from FFprobe
        try {
            let fileInfo = exec(path.join(app.getAppPath(), "../", "bin", "ffprobe"),
            ["-v", "quiet", "-print_format", "json", "-show_format", "-show_streams", filePath], {
                windowsHide: true,
                encoding: "utf8"
            });
            // Process information retrieved from FFprobe
            fileInfo = JSON.parse(fileInfo);
            // Loop through each stream, adding them to the video and audio streams as appropriate
            fileInfo.streams.forEach((stream) => {
                switch (stream.codec_type) {
                    case "video":
                        this.addVideoStream(stream);
                        break;
                    case "audio":
                        this.addAudioStream(stream);
                        break;
                }
            });
        }
        catch (error) {
            this.error = true;
        }
    }

    /**
     * Add a video stream to the file information.
     * @param {Object} stream - The stream from FFprobe to add.
     */
    addVideoStream(stream) {
        // If the video stream is an attached image (e.g. album art), do not process it
        if (stream.disposition.attached_pic != 0) {
            return;
        }
        // Process stream information
        let frameRateFraction = stream.avg_frame_rate.split("/");
        let frameRate = parseInt(frameRateFraction[0]) / parseInt(frameRateFraction[1]);
        let fieldOrder = "progressive";
        if (typeof stream.field_order !== "undefined") {
            switch (stream.field_order) {
                case "tt":
                case "bt":
                    fieldOrder = "top";
                    break;
                case "bb":
                case "tb":
                    fieldOrder = "bottom";
                    break;
            }
        }
        // Create stream information
        let streamInfo = {
            index: stream.index,
            codec: stream.codec_name,
            width: stream.width,
            height: stream.height,
            aspectRatio: stream.display_aspect_ratio,
            frameRate: frameRate,
            fieldOrder: fieldOrder,
            pixelFormat: stream.pix_fmt,
            colourRange: stream.color_range,
            colourSpace: stream.color_space,
            colourTransfer: stream.color_transfer,
            colourPrimaries: stream.colour_primaries
        };
        // Add stream to list of video streams
        this.videoStreams.push(streamInfo);
    }

    /**
     * Add an audio stream to the file information.
     * @param {Object} stream - The stream from FFprobe to add.
     */
    addAudioStream(stream) {
        // Create stream information
        let streamInfo = {
            index: stream.index,
            codec: stream.codec_name,
            sampleRate: parseInt(stream.sample_rate),
            channels: stream.channels
        };
        // Add stream to list of audio streams
        this.audioStreams.push(streamInfo);
    }

    /**
     * Add a new transcode output to the file.
     */
    addOutput() {
        // Create new file path for the output
        let filePath = this.path.substring(0, this.path.lastIndexOf(".")) + "_" + this.newOutputSuffix + ".mp4";
        // Add output
        this.outputs.push(new Output(filePath));
        // Increase output suffix
        this.newOutputSuffix++;
    }

    /**
     * Removes a transcode output from the file
     * @param {Object} output - The output to remove.
     */
    removeOutput(output) {
        this.outputs.splice(this.outputs.indexOf(output), 1);
    }
}

module.exports.File = File;