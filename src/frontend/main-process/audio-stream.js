/** Represents information about an audio stream within a media file. */
export class AudioStream {
    /**
     * The index of the stream within the media file.
     *
     * @type {number}
     */
    index = 0;

    /**
     * The name of the audio codec the stream has been encoded with.
     *
     * @type {string}
     */
    codec = "";

    /**
     * The sample rate of the audio stream.
     *
     * @type {number}
     */
    sampleRate = 0;

    /**
     * The number of audio channels contained within the stream.
     *
     * @type {number}
     */
    channels = 0;
}