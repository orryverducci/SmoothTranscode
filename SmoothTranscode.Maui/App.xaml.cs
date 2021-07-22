using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Application = Microsoft.Maui.Controls.Application;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SmoothTranscode.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState activationState) => new Window(new UI.MainPage());
    }
}
