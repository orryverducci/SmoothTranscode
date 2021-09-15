using Foundation;
using Microsoft.Maui;

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
