using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace SmoothTranscode.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<EncodeManager>();

            return builder.Build();
        }
    }
}
