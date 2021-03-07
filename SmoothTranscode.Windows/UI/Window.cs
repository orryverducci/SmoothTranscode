using System;
using System.Windows;
using System.Windows.Controls;
using Xamarin.Forms.Platform.WPF.Extensions;

namespace SmoothTranscode.Windows.UI
{
    /// <summary>
    /// Provides a user interface window.
    /// </summary>
    public class Window : System.Windows.Window
    {
        /// <summary>
        /// The grid which will contain the window content.
        /// </summary>
        protected Grid WindowGrid { get; private set; } = new Grid();

        /// <summary>
        /// Initialises the window.
        /// </summary>
        protected void InitialiseWindow()
        {
            // Set the window size
            Width = 700;
            Height = 500;

            // Set the grid layout
            WindowGrid.ColumnDefinitions.Add(new ColumnDefinition());
            WindowGrid.RowDefinitions.Add(new RowDefinition());
            WindowGrid.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Auto);
            WindowGrid.RowDefinitions.Add(new RowDefinition());
            WindowGrid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);

            // Add the grid to the window
            AddChild(WindowGrid);
        }

        /// <summary>
        /// Sets up a <see cref="Xamarin.Forms.ContentPage"/> and displays it within the window.
        /// </summary>
        /// <param name="contentPage">The <see cref="Xamarin.Forms.ContentPage"/> to be displayed within the window.</param>
        protected void InitialiseContent(Xamarin.Forms.ContentPage contentPage)
        {
            FrameworkElement content = contentPage.ToFrameworkElement();
            Grid.SetColumn(content, 0);
            Grid.SetRow(content, 1);
            WindowGrid.Children.Add(content);
            if (contentPage.Title != null)
            {
                Title = contentPage.Title;
            }
        }
    }
}
