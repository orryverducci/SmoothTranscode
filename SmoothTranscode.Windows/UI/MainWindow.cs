using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using ModernWpf.Controls;
using SmoothTranscode.UI;

namespace SmoothTranscode.Windows.UI
{
    /// <summary>
    /// The main application window.
    /// </summary>
    public class MainWindow : Window
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="SmoothTranscode.Windows.UI.MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            // Initialise the window and its content
            InitialiseWindow();
            InitialiseContent(new MainWindowContent());

            // Setup the toolbar
            StackPanel buttonStack = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            Button addFileButton = new Button()
            {
                Content = "Add File"
            };
            addFileButton.Click += AddFiles;
            buttonStack.Children.Add(addFileButton);
            Button startConversionButton = new Button()
            {
                Content = "Start Conversion"
            };
            startConversionButton.Click += StartConversion;
            buttonStack.Children.Add(startConversionButton);

            // Add the toolbar
            Grid.SetColumn(buttonStack, 0);
            Grid.SetRow(buttonStack, 0);
            WindowGrid.Children.Add(buttonStack);

            // Display the window
            Show();
        }

        /// <summary>
        /// Shows a file open dialog and adds the selected files to the transcode queue.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        /// <param name="e">The button event arguments.</param>
        private void AddFiles(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    EncodeManager.AddFile(filename);
                }
            }
        }

        private async void StartConversion(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog()
            {
                Content = "Not Yet Implemented",
                IsPrimaryButtonEnabled = true,
                PrimaryButtonText = "OK",
            };
            await dialog.ShowAsync();
        }
    }
}
