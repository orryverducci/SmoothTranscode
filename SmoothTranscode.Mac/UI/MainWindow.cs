using System;
using AppKit;
using Foundation;
using SmoothTranscode.UI;

namespace SmoothTranscode.Mac.UI
{
    /// <summary>
    /// The main application window.
    /// </summary>
    public class MainWindow : Window
    {
        /// <summary>
        /// The file open panel.
        /// </summary>
        private readonly NSOpenPanel _openPanel;

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

            // Setup the open panel used for adding files to the queue
            _openPanel = new NSOpenPanel
            {
                CanChooseFiles = true,
                AllowsMultipleSelection = true,
                CanChooseDirectories = false
            };

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
            switch (identifier)
            {
                case "AddFile":
                    _openPanel.BeginSheet(this, AddFiles);
                    break;
                default:
                    NSAlert alert = new NSAlert()
                    {
                        AlertStyle = NSAlertStyle.Informational,
                        MessageText = "Not Yet Implemented",
                    };
                    alert.BeginSheet(this);
                    break;
            }
        }

        /// <summary>
        /// Adds files from the open panel to the transcode queue.
        /// </summary>
        /// <param name="result">The result of the open panel.</param>
        private void AddFiles(nint result)
        {
            // Check the OK button was clicked
            if (result != (nint)(long)NSModalResponse.OK)
            {
                return;
            }

            // Add each file selected to the queue
            foreach (NSUrl url in _openPanel.Urls)
            {
                EncodeManager.AddFile(url.Path);
            }
        }
    }
}
