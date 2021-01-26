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
        /// Initialises the window.
        /// </summary>
        protected void InitialiseWindow()
        {
            // Set the window style
            AllowsAutomaticWindowTabbing = false;
            BackingType = NSBackingStore.Buffered;
            StyleMask = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled | NSWindowStyle.Miniaturizable;

            // Set the window size and position
            SetFrame(new CGRect((NSScreen.MainScreen.Frame.Width - 700) / 2, (NSScreen.MainScreen.Frame.Height - 500) / 2, 700, 500), true);
        }

        /// <summary>
        /// Sets up a <see cref="Xamarin.Forms.ContentPage"/> and displays it within the window.
        /// </summary>
        /// <param name="contentPage">The <see cref="Xamarin.Forms.ContentPage"/> to be displayed within the window.</param>
        protected void InitialiseContent(ContentPage contentPage)
        {
            ContentViewController = contentPage.CreateViewController();
            if (contentPage.Title != null)
            {
                Title = contentPage.Title;
            }
        }
    }
}
