using System;

namespace SmoothTranscode.UI
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
