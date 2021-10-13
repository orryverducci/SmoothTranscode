using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace SmoothTranscode.Maui
{
    /// <summary>
    /// The application delegate.
    /// </summary>
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
