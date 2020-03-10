import path from "path";
import {app} from "electron";
import {execFileSync as exec} from "child_process";
import {AudioStream} from "./audio-stream.js";
import {VideoStream, fieldOrders} from "./video-stream.js";

/** Represents information about a source media file. */
export class StreamInfo {
    /**
     * The list of video streams contained within the media file.
     *
     * @type {Array.<VideoStream>}
     */
    videoStreams = [];

    /**
     * The list of audio streams contained within the media file.
     *
     * @type {Array.<AudioStream>}
     */
    audioStreams = [];

    /**
     * Initialises an instance of StreamInfo.
     *
     * @param {string} filePath - The path to the file.
     */
    constructor(filePath) {
        // Retrieve information about the file from FFprobe
        try {
            let fileInfo = exec(path.join(app.getAppPath(), "..", "..", "bin", "ffprobe"),
                ["-v", "quiet", "-print_format", "json", "-show_format", "-show_streams", filePath], {
                    windowsHide: true,
                    encoding: "utf8"
                });
            // Process information retrieved from FFprobe
            fileInfo = JSON.parse(fileInfo);
            // Loop through each stream, adding them to the video and audio streams as appropriate
            if (Array.isArray(fileInfo.streams)) {
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
        } catch (error) {
            console.log(error);
        }
    }

    /**
     * Add a video stream to the file information.
     *
     * @param {object} stream - The stream from FFprobe to add.
     */
    addVideoStream(stream) {
        // If the video stream is an attached image (e.g. album art), do not process it
        if (stream.disposition.attached_pic !== 0) {
            return;
        }
        // Process stream information
        let frameRateFraction = stream.avg_frame_rate.split("/");
        let frameRate = parseInt(frameRateFraction[0]) / parseInt(frameRateFraction[1]);
        let fieldOrder = fieldOrders.PROGRESSIVE;
        if (typeof stream.field_order !== "undefined") {
            switch (stream.field_order) {
                case "tt":
                case "bt":
                    fieldOrder = fieldOrders.TOP_FIRST;
                    break;
                case "bb":
                case "tb":
                    fieldOrder = fieldOrders.BOTTOM_FIRST;
                    break;
            }
        }
        // Create stream information
        let streamInfo = new VideoStream();
        streamInfo.index = stream.index;
        streamInfo.codec = stream.codec_name;
        streamInfo.width = stream.width;
        streamInfo.height = stream.height;
        streamInfo.aspectRatio = stream.display_aspect_ratio;
        streamInfo.frameRate = frameRate;
        streamInfo.fieldOrder = fieldOrder;
        streamInfo.pixelFormat = stream.pix_fmt;
        streamInfo.colourRange = stream.color_range;
        streamInfo.colourSpace = stream.color_space;
        streamInfo.colourTransfer = stream.color_transfer;
        streamInfo.colourPrimaries = stream.color_primaries;
        // Add stream to list of video streams
        this.videoStreams.push(streamInfo);
    }

    /**
     * Add an audio stream to the file information.
     *
     * @param {object} stream - The stream from FFprobe to add.
     */
    addAudioStream(stream) {
        // Create stream information
        let streamInfo = new AudioStream();
        streamInfo.index = stream.index;
        streamInfo.codec = stream.codec_name;
        streamInfo.sampleRate = parseInt(stream.sample_rate);
        streamInfo.channels = stream.channels;
        // Add stream to list of audio streams
        this.audioStreams.push(streamInfo);
    }
}