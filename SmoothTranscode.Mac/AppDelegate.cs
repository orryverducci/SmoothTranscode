using System;
using AppKit;
using Foundation;

namespace SmoothTranscode.Mac
{
    /// <summary>
    /// The application delegate.
    /// </summary>
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        /// <summary>
        /// The main application window.
        /// </summary>
        private UI.MainWindow? _mainWindow;

        /// <summary>
        /// The method run when the app is ready to run. Creates the menu and opens the main window.
        /// </summary>
        /// <param name="notification">The broadcast notification.</param>
        public override void DidFinishLaunching(NSNotification notification)
        {
            // Create the application menu
            CreateMenu();

            // Create the main application window
            _mainWindow = new UI.MainWindow();
        }

        /// <summary>
        /// The method run when the last window is closed to indicate if the app should be terminated.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns><see langword="true"/>, indicating the app should terminate.</returns>
        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender) => true;

        /// <summary>
        /// Creates the main menu and puts it in the menu bar.
        /// </summary>
        private void CreateMenu()
        {
            NSMenu menu = new NSMenu();
            CreateApplicationMenu(menu);
            CreateViewMenu(menu);
            CreateWindowMenu(menu);
            CreateHelpMenu(menu);
            NSApplication.SharedApplication.MainMenu = menu;
        }

        /// <summary>
        /// Creates the application submenu.
        /// </summary>
        /// <param name="menu">The menu the submenu should be placed in.</param>
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

        /// <summary>
        /// Creates the view submenu.
        /// </summary>
        /// <param name="menu">The menu the submenu should be placed in.</param>
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

        /// <summary>
        /// Creates the window submenu.
        /// </summary>
        /// <param name="menu">The menu the submenu should be placed in.</param>
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

        /// <summary>
        /// Creates the help submenu.
        /// </summary>
        /// <param name="menu">The menu the submenu should be placed in.</param>
        private void CreateHelpMenu(NSMenu menu)
        {
            // Create the menu
            NSMenuItem helpMenu = new NSMenuItem("Help");
            NSMenu subMenu = new NSMenu("Help");

            // Add the menu items
            subMenu.AddMenuItem("SmoothTranscode Help", "h", "showHelp:");

            // Set the menu as a submenu and add it
            menu.SetSubmenu(subMenu, helpMenu);
            menu.AddItem(helpMenu);
        }
    }
}
