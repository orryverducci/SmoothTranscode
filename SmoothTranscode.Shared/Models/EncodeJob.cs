using System;
using System.Collections.ObjectModel;
using System.IO;

namespace SmoothTranscode.Models
{
    /// <summary>
    /// Represents an encode job containing a source file and one or more outputs.
    /// </summary>
    public class EncodeJob : ObservableCollection<EncodeOutput>
    {
        public MediaFile Source { get; private set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="SmoothTranscode.Models.EncodeJob"/> class.
        /// </summary>
        /// <param name="filename">The file name of the media file.</param>
        public EncodeJob(string filename)
        {
            // Check the file exists
            if (File.Exists(filename))
            {
                Source = new MediaFile(filename);
            }
            else
            {
                throw new FileNotFoundException("The media file could not be found.", filename);
            }
            // Create the initial output
            Add(new EncodeOutput());
        }
    }
}
