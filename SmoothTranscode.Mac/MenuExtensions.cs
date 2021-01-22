using System;
using AppKit;
using ObjCRuntime;

namespace SmoothTranscode.Mac
{
    /// <summary>
    /// Provides extension methods to be used with <see cref="AppKit.NSMenu"/>.
    /// </summary>
    public static class MenuExtensions
    {
        /// <summary>
        /// Adds an item to the menu.
        /// </summary>
        /// <param name="menu">The menu the items should be added to.</param>
        /// <param name="text">The menu item text.</param>
        /// <param name="selector">The selector to be triggered by the menu item.</param>
        public static void AddMenuItem(this NSMenu menu, string text, string selector) => menu.AddMenuItem(text, "", 0, selector);

        /// <summary>
        /// Adds an item to the menu.
        /// </summary>
        /// <param name="menu">The menu the items should be added to.</param>
        /// <param name="text">The menu item text.</param>
        /// <param name="shortcutKey">The shortcut key used to trigger the menu item.</param>
        /// <param name="selector">The selector to be triggered by the menu item.</param>
        public static void AddMenuItem(this NSMenu menu, string text, string shortcutKey, string selector) => menu.AddMenuItem(text, shortcutKey, 0, selector);

        /// <summary>
        /// Adds an item to the menu.
        /// </summary>
        /// <param name="menu">The menu the items should be added to.</param>
        /// <param name="text">The menu item text.</param>
        /// <param name="shortcutKey">The shortcut key used to trigger the menu item.</param>
        /// <param name="keyModifier">The key modifier for the shortcut key.</param>
        /// <param name="selector">The selector to be triggered by the menu item.</param>
        public static void AddMenuItem(this NSMenu menu, string text, string shortcutKey, NSEventModifierMask keyModifier, string selector)
        {
            NSMenuItem menuItem = new NSMenuItem(text, new Selector(selector), shortcutKey);
            if (keyModifier != 0)
            {
                menuItem.KeyEquivalentModifierMask = keyModifier;
            }
            menu.AddItem(menuItem);
        }
    }
}
