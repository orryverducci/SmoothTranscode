/** Provides information and transcode settings a media file. */
class File {
    /**
     * Initialises an instance of File.
     * @param {string} filePath - The path to the file.
     */
    constructor(filePath) {
        // Set the file path
        this.path = filePath;
        // Generate unique ID, based on timestamp plus a random number
        this.id = Date.now() + Math.round(Math.random() * 10e5);
    }
}

module.exports.File = File;