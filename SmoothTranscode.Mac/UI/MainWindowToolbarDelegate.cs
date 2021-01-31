using System;
using AppKit;

namespace SmoothTranscode.Mac.UI
{
    /// <summary>
    /// The delegate for the toolbar on the main application window.
    /// </summary>
    public class MainWindowToolbarDelegate : NSToolbarDelegate
    {
        /// <summary>
        /// Event fired when a button on the toolbar is clicked.
        /// </summary>
        public event EventHandler<string>? ToolbarButtonClicked;

        /// <summary>
        /// Returns a list of allowed toolbar item identifiers.
        /// </summary>
        /// <param name="toolbar">The toolbar.</param>
        /// <returns>A list of allowed toolbar item identifiers.</returns>
        public override string[] AllowedItemIdentifiers(NSToolbar toolbar)
        {
            // Return the list of available item identifiers
            return new string[0];
        }

        /// <summary>
        /// Returns a list of the toolbar item identifiers that a visible by default.
        /// </summary>
        /// <param name="toolbar">The toolbar.</param>
        /// <returns>A list of the default toolbar item identifiers.</returns>
        public override string[] DefaultItemIdentifiers(NSToolbar toolbar)
        {
            // Return the item identifiers that make up the default Toolbar
            return new string[0];
        }

        /// <summary>
        /// Method run when a toolbar item is about to be inserted on to the toolbar. Responsible for creating the toolbar item.
        /// </summary>
        /// <param name="toolbar">The toolbar.</param>
        /// <param name="itemIdentifier">The item identifier being inserted.</param>
        /// <param name="willBeInserted">Whether the item is about to be inserted.</param>
        /// <returns></returns>
        public override NSToolbarItem WillInsertItem(NSToolbar toolbar, string itemIdentifier, bool willBeInserted)
        {
            // Create the toolbar item
            NSToolbarItem item = new NSToolbarItem(itemIdentifier);

            // Setup the toolbar item based on the identifier
            switch (itemIdentifier)
            {
                case "AddFile":
                    item.View = new NSButton()
                    {
                        BezelStyle = NSBezelStyle.TexturedRounded,
                        Image = NSImage.GetSystemSymbol("plus", "Add"),
                        ImagePosition = NSCellImagePosition.ImageLeft,
                        Title = "Add File"
                    };
                    break;
                case "StartConversion":
                    item.View = new NSButton()
                    {
                        Image = NSImage.GetSystemSymbol("play", "Start"),
                        ImagePosition = NSCellImagePosition.ImageLeft,
                        BezelStyle = NSBezelStyle.TexturedRounded,
                        Title = "Start Conversion"
                    };
                    break;
            }

            // Set the clicked event to be fired when the toolbar item is activated
            item.Activated += (sender, e) => ToolbarButtonClicked?.Invoke(sender, itemIdentifier);

            // Return the toolbar item
            return item;
        }
    }
}
