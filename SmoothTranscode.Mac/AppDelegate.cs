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
            subMenu.AddMenuItem($"About {appName}", "orderFrontStandardAboutPanel:");
            subMenu.AddItem(NSMenuItem.SeparatorItem);
            NSMenuItem servicesMenuItem = new NSMenuItem("Services");
            NSMenu servicesSubMenu = new NSMenu("Services");
            subMenu.SetSubmenu(servicesSubMenu, servicesMenuItem);
            NSApplication.SharedApplication.ServicesMenu = servicesSubMenu;
            subMenu.AddItem(servicesMenuItem);
            subMenu.AddItem(NSMenuItem.SeparatorItem);
            subMenu.AddMenuItem($"Hide {appName}", "h", "hide:");
            subMenu.AddMenuItem("Hide Others", "h", NSEventModifierMask.AlternateKeyMask | NSEventModifierMask.CommandKeyMask, "hideOtherApplications:");
            subMenu.AddMenuItem("Show All", "unhideAllApplications:");
            subMenu.AddItem(NSMenuItem.SeparatorItem);
            subMenu.AddMenuItem($"Quit {appName}", "q", "terminate:");

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
            subMenu.AddMenuItem("Enter Full Screen", "f", NSEventModifierMask.CommandKeyMask | NSEventModifierMask.ControlKeyMask, "toggleFullScreen:");

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
            subMenu.AddMenuItem("Close", "w", "performClose:");
            subMenu.AddMenuItem("Minimize", "m", "performMiniaturize:");
            subMenu.AddMenuItem("Zoom", "\r", NSEventModifierMask.ShiftKeyMask | NSEventModifierMask.CommandKeyMask, "performZoom:");
            subMenu.AddItem(NSMenuItem.SeparatorItem);
            subMenu.AddMenuItem("Bring All to Front", "arrangeInFront:");

            // Set the menu as a submenu and add it
            NSApplication.SharedApplication.WindowsMenu = subMenu;
            menu.SetSubmenu(subMenu, windowMenu);
            menu.AddItem(windowMenu);
        }
    }
}
