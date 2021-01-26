using System;
using AppKit;
using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace SmoothTranscode.Mac.UI
{
    /// <summary>
    /// Provides a user interface window.
    /// </summary>
    public class Window : NSWindow
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="SmoothTranscode.Mac.UI.Window"/> class.
        /// </summary>
        /// <param name="page">The <see cref="Xamarin.Forms.ContentPage"/> to be displayed within the window.</param>
        public Window(ContentPage page)
        {
            // Set the window style
            AllowsAutomaticWindowTabbing = false;
            BackingType = NSBackingStore.Buffered;
            StyleMask = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled | NSWindowStyle.Miniaturizable;

            // Set the window size and position
            SetFrame(new CGRect((NSScreen.MainScreen.Frame.Width - 700) / 2, (NSScreen.MainScreen.Frame.Height - 500) / 2, 700, 500), true);

            // Add the provided page to the window and set the title from the content page
            NSViewController viewController = page.CreateViewController();
            ContentViewController = viewController;
            if (page.Title != null)
            {
                Title = page.Title;
            }

            // Display the window
            MakeKeyAndOrderFront(NSApplication.SharedApplication);
        }
    }
}
