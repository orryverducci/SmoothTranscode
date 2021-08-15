using System;
using System.Collections.ObjectModel;
using SmoothTranscode.Models;

namespace SmoothTranscode
{
    /// <summary>
    /// Manages the files to be encoded.
    /// </summary>
    public class EncodeManager
    {
        /// <summary>
        /// The queue of encode jobs.
        /// </summary>
        public ObservableCollection<EncodeJob> JobQueue { get; private set; } = new ObservableCollection<EncodeJob>();

        /// <summary>
        /// Adds a file to the encode job queue.
        /// </summary>
        /// <param name="path"></param>
        public void AddFile(string path) => JobQueue.Add(new EncodeJob(path));
    }
}
