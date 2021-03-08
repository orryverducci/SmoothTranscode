using System;
using Foundation;
using ObjCRuntime;

namespace SmoothTranscode.UI
{
    /// <summary>
    /// Provides platform specific functionality indicating the current system theme.
    /// </summary>
    public class AppTheme : NSObject
    {
        /// <summary>
        /// The available themes.
        /// </summary>
        public enum Theme
        {
            Light,
            Dark
        }

        /// <summary>
        /// Specifies if the theme change observer has been set.
        /// </summary>
        private readonly bool _observerSet;

        /// <summary>
        /// The current system theme.
        /// </summary>
        public Theme Current { get; private set; }

        /// <summary>
        /// Event fired when the system theme has changed.
        /// </summary>
        public event EventHandler ThemeChanged;

        /// <summary>
        /// Initialises a new instance of the <see cref="SmoothTranscode.UI.AppTheme"/> class.
        /// </summary>
        public AppTheme()
        {
            // Get the OS version
            Version version;
            using (NSProcessInfo info = new NSProcessInfo())
            {
                version = new Version((int)info.OperatingSystemVersion.Major, (int)info.OperatingSystemVersion.Minor);
            }

            // If the OS supports themes, get the theme and set an observer for changes, otherwise use the light theme
            if (version >= new Version(10, 14))
            {
                NSDistributedNotificationCenter.GetDefaultCenter().AddObserver(this, new Selector("osThemeChanged:"), "AppleInterfaceThemeChangedNotification", null);
                _observerSet = true;
                UpdateTheme();
            }
            else
            {
                Current = Theme.Light;
            }
        }

        /// <summary>
        /// Destructor for the the <see cref="SmoothTranscode.UI.AppTheme"/> class.
        /// </summary>
        ~AppTheme()
        {
            if (_observerSet)
            {
                NSDistributedNotificationCenter.GetDefaultCenter().RemoveObserver(this, "AppleInterfaceThemeChangedNotification");
            }
        }

        /// <summary>
        /// Gets the new system theme and updates the current theme accordingly.
        /// </summary>
        private void UpdateTheme()
        {
            string? appearance = NSUserDefaults.StandardUserDefaults.StringForKey("AppleInterfaceStyle");

            if (!string.IsNullOrEmpty(appearance) && appearance == "Dark")
            {
                Current = Theme.Dark;
            }
            else
            {
                Current = Theme.Light;
            }

            ThemeChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Callback used to received the theme change notification and update the theme.
        /// </summary>
        /// <param name="change">The notification.</param>
        [Export("osThemeChanged:")]
        public void OSThemeChanged(NSObject change) => UpdateTheme();
    }
}
