using System;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Windows.ApplicationModel;

namespace SmoothTranscode
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
	{
		/// <summary>
		/// Initialises a new instance of the <see cref="T:SmoothTranscode.App"/> class.
		/// </summary>
		public App()
		{
			ConfigureLogging(Uno.Extensions.LogExtensionPoint.AmbientLoggerFactory);

			InitializeComponent();

			Suspending += OnSuspending;
		}

		/// <summary>
		/// Invoked when the application is launched by the user.
		/// </summary>
		/// <param name="e">Details about the launch request and process.</param>
		protected override void OnLaunched(LaunchActivatedEventArgs e)
		{
			// Get or create the window
#if NET5_0 && WINDOWS
			Window window = new Window();
			window.Activate();
#else
			Window window = Window.Current;
#endif

			Frame? rootFrame = window.Content as Frame;

			// Do not repeat app initialization when the window already has content, just ensure that the window is active
			if (rootFrame == null)
			{
				// Create a Frame to act as the navigation context and navigate to the first page
				rootFrame = new Frame();
				rootFrame.NavigationFailed += OnNavigationFailed;

				// Place the frame in the current window
				window.Content = rootFrame;
			}

#if !(NET5_0 && WINDOWS)
			if (e.UWPLaunchActivatedEventArgs.PrelaunchActivated == false)
#endif
			{
				if (rootFrame.Content == null)
				{
					// When the navigation stack isn't restored navigate to the first page,
					// configuring the new page by passing required information as a navigation
					// parameter
					rootFrame.Navigate(typeof(MainPage), e.Arguments);
				}

				// Ensure the current window is active
				window.Activate();
			}
		}

		/// <summary>
		/// Invoked when navigation to a page fails.
		/// </summary>
		/// <param name="sender">The frame which failed navigation.</param>
		/// <param name="e">Details about the failure.</param>
		private void OnNavigationFailed(object sender, NavigationFailedEventArgs e) =>
			throw new Exception($"Failed to load {e.SourcePageType.FullName}: {e.Exception}");

		/// <summary>
		/// Invoked when application execution is being suspended. Application state is saved
		/// without knowing whether the application will be terminated or resumed with the contents
		/// of memory still intact.
		/// </summary>
		/// <param name="sender">The source of the suspend request.</param>
		/// <param name="e">Details about the suspend request.</param>
		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
            SuspendingDeferral deferral = e.SuspendingOperation.GetDeferral();
			deferral.Complete();
		}

		/// <summary>
        /// Configures logging.
        /// </summary>
        /// <param name="factory">The factory that builds the logging system.</param>
		private void ConfigureLogging(ILoggerFactory factory)
		{
			factory
				.WithFilter(new FilterLoggerSettings
					{
						{ "Uno", LogLevel.Warning },
						{ "Windows", LogLevel.Warning },
						{ "Microsoft", LogLevel.Warning },
					}
				)
#if DEBUG
				.AddConsole(LogLevel.Debug);
#else
				.AddConsole(LogLevel.Information);
#endif
		}
    }
}
