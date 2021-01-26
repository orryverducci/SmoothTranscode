using System;
using SmoothTranscode.UI;

namespace SmoothTranscode.Mac.UI
{
    /// <summary>
    /// The main application window.
    /// </summary>
    public class MainWindow : Window
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="SmoothTranscode.UI.MainWindow"/> class.
        /// </summary>
        public MainWindow() : base(new MainWindowContent())
        {
        }
    }
}
