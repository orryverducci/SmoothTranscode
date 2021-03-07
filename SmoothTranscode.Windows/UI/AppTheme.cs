using System;

namespace SmoothTranscode.UI
{
    /// <summary>
    /// Provides platform specific functionality indicating the current system theme.
    /// </summary>
    /// <remarks>
    /// WPF doesn't directly support system themes, so this is provided as a placeholder.
    /// </remarks>
    public class AppTheme
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
        /// The current system theme.
        /// </summary>
        public Theme Current { get => Theme.Light; }

        /// <summary>
        /// Event fired when the system theme has changed.
        /// </summary>
        public event EventHandler ThemeChanged;
    }
}
