using System;
using AppKit;
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
        public MainWindow()
        {
            // Initialise the window and its content
            InitialiseWindow();
            InitialiseContent(new MainWindowContent());

            // Display the window
            MakeKeyAndOrderFront(NSApplication.SharedApplication);
        }
    }
}
