using System;
using GLib;
using Uno.UI.Runtime.Skia;

namespace SmoothTranscode.Linux
{
    /// <summary>
    /// Responsible for starting up the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The entry point for the application.
        /// </summary>
        /// <param name="args">The command line arguments the application is launched with.</param>
        public static void Main(string[] args)
        {
            ExceptionManager.UnhandledException += delegate (UnhandledExceptionArgs expArgs)
            {
                Console.WriteLine("GLIB UNHANDLED EXCEPTION" + expArgs.ExceptionObject.ToString());
                expArgs.ExitApplication = true;
            };

            GtkHost host = new GtkHost(() => new App(), args);

            host.Run();
        }
    }
}
