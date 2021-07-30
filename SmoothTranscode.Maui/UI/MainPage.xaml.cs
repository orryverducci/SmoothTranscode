using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SmoothTranscode.Maui.UI
{
    /// <summary>
    /// The page containing the content of the main window.
    /// </summary>
    public partial class MainPage : ContentPage, IPage
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="SmoothTranscode.Maui.UI.MainPage"/> class.
        /// </summary>
        public MainPage() => InitializeComponent();

        async private void AddFileClicked(object sender, EventArgs args)
        {
            await DisplayAlert("Not Yet Implemented", "This feature has not yet been implemented", "OK");
        }

        async private void StartConversionClicked(object sender, EventArgs args)
        {
            await DisplayAlert("Not Yet Implemented", "This feature has not yet been implemented", "OK");
        }
    }
}
