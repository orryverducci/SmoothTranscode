using System;
using System.Windows;
using Xamarin.Forms;

namespace SmoothTranscode.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            Forms.Init();
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            MainWindow = new UI.MainWindow();
        }
    }
}
