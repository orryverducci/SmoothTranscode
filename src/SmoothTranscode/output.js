/** Provides information and transcode settings for an individual transcode output. */
class Output {
    /**
     * Initialises an instance of Output.
     * @param {string} filePath - The initial path to the output file.
     */
    constructor(filePath) {
        // Set the initial file path
        this.path = filePath;
        // Generate unique ID, based on timestamp plus a random number
        this.id = Date.now() + Math.round(Math.random() * 10e5);
    }
}

module.exports.Output = Output;