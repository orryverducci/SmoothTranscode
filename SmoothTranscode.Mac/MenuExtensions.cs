using System;
using AppKit;
using ObjCRuntime;

namespace SmoothTranscode.Mac
{
    public static class MenuExtensions
    {
        public static void AddMenuItem(this NSMenu menu, string text, string selector) => menu.AddMenuItem(text, "", 0, selector);

        public static void AddMenuItem(this NSMenu menu, string text, string shortcutKey, string selector) => menu.AddMenuItem(text, shortcutKey, 0, selector);

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
