using System;
using System.Collections.ObjectModel;
using SmoothTranscode.Models;

namespace SmoothTranscode
{
    /// <summary>
    /// Manages the files to be encoded.
    /// </summary>
    public static class EncodeManager
    {
        /// <summary>
        /// The queue of media files to be transcoded.
        /// </summary>
        public static ObservableCollection<MediaFile> FileQueue { get; private set; } = new ObservableCollection<MediaFile>();

        /// <summary>
        /// Adds a file to the queue of media files to be transcoded.
        /// </summary>
        /// <param name="path"></param>
        public static void AddFile(string path) => FileQueue.Add(new MediaFile(path));
    }
}