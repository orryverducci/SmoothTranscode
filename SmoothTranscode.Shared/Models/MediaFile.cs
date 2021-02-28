using System;

namespace SmoothTranscode.Models
{
    /// <summary>
    /// Represents a media file.
    /// </summary>
    public class MediaFile
    {
        /// <summary>
        /// The file name.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// The type of media contained in the file.
        /// </summary>
        public MediaType Type { get; private set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="SmoothTranscode.Models.MediaFile"/> class.
        /// </summary>
        /// <param name="filename">The file name of the media file.</param>
        public MediaFile(string filename)
        {
            FileName = filename;
        }
    }
}
