using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chronicle
{
    /// <summary>
    /// View model for the settings view
    /// </summary>
    public class SettingsPageViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The kind of theme for this application
        /// </summary>
        public ThemeKind Theme { get; set; }

        /// <summary>
        /// The pointer to the theme resource file
        /// </summary>
        public IThemeUri ThemeUri { get; set; }

        /// <summary>
        /// True if light theme is active
        /// </summary>
        public bool IsLightThemeActive 
        {
            get => Theme == ThemeKind.LightTheme;
            set { }
        }

        /// <summary>
        /// True if dark theme is active
        /// </summary>
        public bool IsDarkThemeActive
        {
            get => Theme == ThemeKind.DarkTheme;
            set { }
        }

        /// <summary>
        ///  True if plain template is active
        /// </summary>
        public bool IsPlainTemplateActive
        {
            get => DI.TabContentVM.Template == TabContentTemplates.Plain;
            set { }
        }

        /// <summary>
        ///  True if lined template is active
        /// </summary>
        public bool IsLinedTemplateActive
        {
            get => DI.TabContentVM.Template == TabContentTemplates.Lined;
            set { }
        }

        /// <summary>
        ///  True if margin line template is active
        /// </summary>
        public bool IsMarginLinedTemplateActive
        {
            get => DI.TabContentVM.Template == TabContentTemplates.LinedWithMargin;
            set { }
        }

        #endregion

        #region Public Command

        /// <summary>
        /// Command to set tab template to use lined template
        /// </summary>
        public ICommand LinedTemplateCommand { get; set; }

        /// <summary>
        /// Command to set tab template to use plain template
        /// </summary>
        public ICommand PlainTemplateCommand { get; set; }

        /// <summary>
        /// Command to set tab template to use lined with margin template
        /// </summary>
        public ICommand LinedWithMarginTemplateCommand { get; set; }

        /// <summary>
        /// Command to set this application to a light theme mode
        /// </summary>
        public ICommand LightThemeCommand { get; set; }

        /// <summary>
        /// Command to set this application to a dark theme mode
        /// </summary>
        public ICommand DarkThemeCommand { get; set; }

        /// <summary>
        /// Command to set this application to use light or dark theme mode (Depending on theme mode of the machine this application is running on)
        /// </summary>
        //public ICommand UseSystemSettingsThemeCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingsPageViewModel()
        {
            // Set properties
            Theme = ThemeKind.DarkTheme;
            ThemeUri = (IThemeUri)Application.Current;

            // Create commands
            LinedTemplateCommand = new RelayCommand(() => DI.TabContentVM.Template = TabContentTemplates.Lined);
            PlainTemplateCommand = new RelayCommand(() => DI.TabContentVM.Template = TabContentTemplates.Plain);
            LinedWithMarginTemplateCommand = new RelayCommand(() => DI.TabContentVM.Template = TabContentTemplates.LinedWithMargin);
            LightThemeCommand = new RelayCommand(TurnOnLightTheme);
            DarkThemeCommand = new RelayCommand(TurnOnDarkTheme);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Turn on the dark theme mode
        /// </summary>
        private void TurnOnDarkTheme()
        {
            // Get the current theme before switching to another theme
            var themeToChange = Theme;

            // Set and Change to dark theme
            Theme = ThemeKind.DarkTheme;
            SetNewTheme((themeToChange).ToString());
        }

        /// <summary>
        /// Turn on the light theme mode
        /// </summary>
        private void TurnOnLightTheme()
        {
            // Get the current theme before switching to another theme
            var themeToChange = Theme;

            // Set and Change to light theme
            Theme = ThemeKind.LightTheme;
            SetNewTheme((themeToChange).ToString()); 
        }

        #endregion

        #region Method

        /// <summary>
        /// Removes and set desired theme
        /// </summary>
        /// <param name="themeToTurnOff">The current theme to remove</param>
        public void SetNewTheme(string themeToTurnOff)
        {
            // Get current theme
            var currentTheme = ThemeUri.GetTheme.FirstOrDefault(resrc => resrc.Source == new Uri($"Styles\\Themes\\{themeToTurnOff}.xaml", UriKind.RelativeOrAbsolute));

            // If we have current theme
            if (currentTheme != null)
            {
                // Sort and switch as needed
                switch (Theme)
                {
                    // Change to light theme
                    case ThemeKind.LightTheme:
                        ThemeUri.GetTheme.Remove(currentTheme);
                        ThemeUri.GetTheme.Add(new ResourceDictionary { Source = new Uri("Styles\\Themes\\LightTheme.xaml", UriKind.Relative) });
                        break;

                    // Change to dark theme
                    case ThemeKind.DarkTheme:
                        ThemeUri.GetTheme.Remove(currentTheme);
                        ThemeUri.GetTheme.Add(new ResourceDictionary { Source = new Uri("Styles\\Themes\\DarkTheme.xaml", UriKind.Relative) });
                        break;

                }

            }

        }

        #endregion

    }
}
