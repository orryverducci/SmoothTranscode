using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Application = Microsoft.Maui.Controls.Application;

namespace SmoothTranscode.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new UI.MainPage();
        }
    }
}
