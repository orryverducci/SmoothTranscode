using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmoothTranscode.UI
{
    /// <summary>
    /// A XAML markup extension which allows light and dark colours to be set, and provides one as its value depending on the current system theme.
    /// </summary>
    /// <remarks>
    /// We use this in place of the one provided by Xamarin.Forms as it triggers a <see cref="System.NullReferenceException"/> on WPF.
    /// </remarks>
    public class AppThemeBindingExtension : IMarkupExtension<BindingBase>, INotifyPropertyChanged
    {
        /// <summary>
        /// The platform specific app theme implementation.
        /// </summary>
        private readonly AppTheme _appTheme = new AppTheme();

        /// <summary>
        /// The light theme colour.
        /// </summary>
        public Color Light { set; get; }

        /// <summary>
        /// The dark theme colour.
        /// </summary>
        public Color Dark { set; get; }

        /// <summary>
        /// The current colour value, depending on the current system theme.
        /// </summary>
        public Color Current { get => _appTheme.Current == AppTheme.Theme.Light ? Light : Dark; }

        /// <summary>
        /// Event fired when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Initialises a new instance of the <see cref="SmoothTranscode.UI.AppThemeBindingExtension"/> class.
        /// </summary>
        public AppThemeBindingExtension() => _appTheme.ThemeChanged += (sender, e) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Current"));

        /// <summary>
        /// Provides the binding to the current value.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>A binding to the current value.</returns>
        public BindingBase ProvideValue(IServiceProvider serviceProvider) => new Binding("Current", BindingMode.OneWayToSource, source: this);

        /// <summary>
        /// Provides the binding to the current value.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>A binding to the current value.</returns>
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => (this as IMarkupExtension<BindingBase>).ProvideValue(serviceProvider);
    }
}
