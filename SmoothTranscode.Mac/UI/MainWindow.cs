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
        /// Initialises a new instance of the <see cref="SmoothTranscode.Mac.UI.MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            // Initialise the window and its content
            InitialiseWindow();
            InitialiseContent(new MainWindowContent());

            // Setup the toolbar
            Toolbar = new NSToolbar();
            ToolbarStyle = NSWindowToolbarStyle.UnifiedCompact;
            MainWindowToolbarDelegate toolbarDelegate = new MainWindowToolbarDelegate();
            toolbarDelegate.ToolbarButtonClicked += ToolbarButtonClicked;
            Toolbar.Delegate = toolbarDelegate;

            // Insert the toolbar items
            Toolbar.InsertItem("AddFile", 0);
            Toolbar.InsertItem("StartConversion", 1);

            // Display the window
            MakeKeyAndOrderFront(NSApplication.SharedApplication);
        }

        /// <summary>
        /// Fired when a toolbar button is clicked.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        /// <param name="identifier">The identifier of the button that has been clicked.</param>
        private void ToolbarButtonClicked(object sender, string identifier)
        {
            NSAlert alert = new NSAlert()
            {
                AlertStyle = NSAlertStyle.Informational,
                MessageText = "Not Yet Implemented",
            };
            alert.BeginSheet(this);
        }
    }
}
