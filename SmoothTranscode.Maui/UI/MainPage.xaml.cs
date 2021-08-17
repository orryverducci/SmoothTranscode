using System;
using System.Collections.Generic;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace SmoothTranscode.Maui.UI
{
    /// <summary>
    /// The page containing the content of the main window.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private readonly EncodeManager _encodeManager = Services.ServiceProvider.GetService<EncodeManager>();

        /// <summary>
        /// Initialises a new instance of the <see cref="SmoothTranscode.Maui.UI.MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _encodeManager;
        }

        async private void AddFileClicked(object sender, EventArgs args)
        {
            PickOptions options = new()
            {
                FileTypes = FilePickerFileType.Videos
            };
            IEnumerable<FileResult> files = await FilePicker.PickMultipleAsync(options);

            foreach (FileResult file in files)
            {
                _encodeManager.AddFile(file.FullPath);
            }
        }

        async private void StartConversionClicked(object sender, EventArgs args)
        {
            await DisplayAlert("Not Yet Implemented", "This feature has not yet been implemented", "OK");
        }
    }
}
