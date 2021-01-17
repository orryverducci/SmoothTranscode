using System;
using AppKit;
using Foundation;
using ObjCRuntime;

namespace SmoothTranscode.Mac
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        private UI.MainWindow? _mainWindow;

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Create the application menu
            CreateMenu();

            // Create the main application window
            _mainWindow = new UI.MainWindow();
        }

        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender) => true;

        private void CreateMenu()
        {
            NSMenu menu = new NSMenu();
            CreateApplicationMenu(menu);
            CreateViewMenu(menu);
            CreateWindowMenu(menu);
            NSApplication.SharedApplication.MainMenu = menu;
        }

        private void CreateApplicationMenu(NSMenu menu)
        {
            // Get the application name
            NSObject title = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleName");
            string appName = title.ToString();

            // Create the menu
            NSMenuItem appMenu = new NSMenuItem(appName);
            NSMenu subMenu = new NSMenu(appName);

            // Add the menu items
            NSMenuItem aboutMenuItem = CreateMenuItem($"About {appName}", "orderFrontStandardAboutPanel:");
            subMenu.AddItem(aboutMenuItem);
            subMenu.AddItem(NSMenuItem.SeparatorItem);
            NSMenuItem servicesMenuItem = new NSMenuItem("Services");
            NSMenu servicesSubMenu = new NSMenu("Services");
            subMenu.SetSubmenu(servicesSubMenu, servicesMenuItem);
            NSApplication.SharedApplication.ServicesMenu = servicesSubMenu;
            subMenu.AddItem(servicesMenuItem);
            subMenu.AddItem(NSMenuItem.SeparatorItem);
            NSMenuItem hideMenuItem = CreateMenuItem($"Hide {appName}", "h", "hide:");
            subMenu.AddItem(hideMenuItem);
            NSMenuItem hideOthersMenuItem = CreateMenuItem("Hide Others", "h", NSEventModifierMask.AlternateKeyMask | NSEventModifierMask.CommandKeyMask, "hideOtherApplications:");
            subMenu.AddItem(hideOthersMenuItem);
            NSMenuItem showAllMenuItem = CreateMenuItem("Show All", "unhideAllApplications:");
            subMenu.AddItem(showAllMenuItem);
            subMenu.AddItem(NSMenuItem.SeparatorItem);
            NSMenuItem quitMenuItem = CreateMenuItem($"Quit {appName}", "q", "terminate:");
            subMenu.AddItem(quitMenuItem);

            // Set the menu as a submenu and add it
            menu.SetSubmenu(subMenu, appMenu);
            menu.AddItem(appMenu);
        }

        private void CreateViewMenu(NSMenu menu)
        {
            // Create the menu
            NSMenuItem viewMenu = new NSMenuItem("View");
            NSMenu subMenu = new NSMenu("View");

            // Add the menu items
            NSMenuItem fullScreenMenuItem = CreateMenuItem("Enter Full Screen", "f", NSEventModifierMask.CommandKeyMask | NSEventModifierMask.ControlKeyMask, "toggleFullScreen:");
            subMenu.AddItem(fullScreenMenuItem);

            // Set the menu as a submenu and add it
            menu.SetSubmenu(subMenu, viewMenu);
            menu.AddItem(viewMenu);
        }

        private void CreateWindowMenu(NSMenu menu)
        {
            // Create the menu
            NSMenuItem windowMenu = new NSMenuItem("Window");
            NSMenu subMenu = new NSMenu("Window");

            // Add the menu items
            NSMenuItem minimizeMenuItem = CreateMenuItem("Minimize", "m", "performMiniaturize:");
            subMenu.AddItem(minimizeMenuItem);
            NSMenuItem zoomMenuItem = CreateMenuItem("Zoom", "performZoom:");
            subMenu.AddItem(zoomMenuItem);
            subMenu.AddItem(NSMenuItem.SeparatorItem);
            NSMenuItem bringAllFrontMenuItem = CreateMenuItem("Bring All to Front", "arrangeInFront:");
            subMenu.AddItem(bringAllFrontMenuItem);

            // Set the menu as a submenu and add it
            menu.SetSubmenu(subMenu, windowMenu);
            menu.AddItem(windowMenu);
        }

        private NSMenuItem CreateMenuItem(string text, string selector) => CreateMenuItem(text, "", 0, selector);

        private NSMenuItem CreateMenuItem(string text, string shortcutKey, string selector) => CreateMenuItem(text, shortcutKey, 0, selector);

        private NSMenuItem CreateMenuItem(string text, string shortcutKey, NSEventModifierMask keyModifier, string selector)
        {
            NSMenuItem menuItem = new NSMenuItem(text, new Selector(selector), shortcutKey);
            if (keyModifier != 0)
            {
                menuItem.KeyEquivalentModifierMask = keyModifier;
            }
            return menuItem;
        }
    }
}
