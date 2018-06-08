/** Provides transcode settings. */
class Settings {
    constructor() {
        // Initialise default preset name
        this.presetName = "Default";
        // Initialise default container
        this.container = "mp4";
        // Initialise default video encoding settings
        this.videoCodec = "mpeg2video";
        // Initialise default audio encoding settings
        this.audioCodec = "aac";
    }
}

module.exports.Settings = Settings;