/**
 * The available field orders.
 * 
 * @type {object}
 * @property {string} PROGRESSIVE - Progressive.
 * @property {string} TOP_FIRST - Interlaced, top field first.
 * @property {string} BOTTOM_FIRST - Interlaced, bottom field first.
 */
export let fieldOrders = {
    PROGRESSIVE: "progressive",
    TOP_FIRST: "top",
    BOTTOM_FIRST: "bottom"
}

/** Represents information about a video stream within a media file. */
export class VideoStream {
    /**
     * The index of the stream within the media file.
     *
     * @type {number}
     */
    index = 0;

    /**
     * The name of the video codec the stream has been encoded with.
     *
     * @type {string}
     */
    codec = "";

    /**
     * The video's horizontal resolution.
     *
     * @type {number}
     */
    width = 0;

    /**
     * The video's vertical resolution.
     *
     * @type {number}
     */
    height = 0;

    /**
     * The display aspect ratio of the video, expressed as x:y.
     *
     * @type {string}
     */
    aspectRatio = "1:1";

    /**
     * The frame rate of the video.
     *
     * @type {number}
     */
    frameRate = 0;

    /**
     * The field order for the video, representing if the video is progressive or interlaced, and if it is interlaced which field comes first.
     *
     * @type {fieldOrders}
     */
    fieldOrder = fieldOrders.PROGRESSIVE;

    /**
     * The pixel format of the video.
     *
     * @type {string}
     */
    pixelFormat = "yuv420p";

    /**
     * The colour range (limited or full) used by the video.
     *
     * @type {string}
     */
    colourRange = "tv";

    /**
     * The colour space used by the video.
     *
     * @type {string}
     */
    colourSpace = "bt709";

    /**
     * The colour transfer curve used by the video.
     *
     * @type {string}
     */
    colourTransfer = "bt709";

    /**
     * The colour primaries use by the video.
     *
     * @type {string}
     */
    colourPrimaries = "bt709";
}