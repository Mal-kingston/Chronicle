using Dna;
using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static Chronicle.DI;

namespace Chronicle
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IThemeUri
    {
        /// <summary>
        /// Merged dictionaries of this application
        /// </summary>
        public Collection<ResourceDictionary>? GetTheme 
        {
            get => Current.Resources.MergedDictionaries; 
            set { }
        }

        /// <summary>
        /// Configuration of this application
        /// </summary>
        protected AppConfiguration AppConfiguration { get; set; } = new AppConfiguration();

        /// <summary>
        /// Manually handle application starting up
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Setup the main application
            ApplicationSetup();

            // Log information
            Logger.Log("Application services setup completed.");

            // Show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Manually handle application exiting
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e)
        {
            // Get configuration 
            var config = (AppSettings)AppConfiguration.AppConfig.GetSection("AppSettings");

            // Set state of this application to save
            config.Theme = SettingsVM.Theme;
            config.Template = TabContentVM.Template;
            
            // Save configuration
            AppConfiguration.AppConfig.Save();
        }

        /// <summary>
        /// Configure this application
        /// </summary>
        private async void ApplicationSetup()
        {
            // Setup the Dna framework
            Framework.Construct<DefaultFrameworkConstruction>()
                     .AddPages()
                     .AddViewModels()
                     .AddClientDataStore()
                     .AddFileManager()
                     .AddLoggers()
                     .AddUIManager()
                     .Build();

            // Make sure data store is available
            await ClientDataStore.DataStoreAvailable();

            // Grab a copy of the client data store
            AccessInMemoryDb.GetCopyOfDbData();

            // Populate recycle bin as needed
            AccessInMemoryDb.UpdateRecycleBin();

            // Get app configuration
            var config = (AppSettings)AppConfiguration.AppConfig.GetSection("AppSettings");

            // If we have configuration...
            if(config != null )
            {
                // Set saved data
                SettingsVM.Theme = (ThemeKind)config.Theme!;
                TabContentVM.Template = (TabContentTemplates)config.Template!;

                // Switch themes accordingly on-startup
                switch(SettingsVM.Theme)
                {
                    // Light theme
                    case ThemeKind.LightTheme:
                        SettingsVM.LightThemeCommand.Execute(true);
                        break;
                    // Dark theme
                    case ThemeKind.DarkTheme:
                        SettingsVM.DarkThemeCommand.Execute(true);
                        break;
                }
            }

        }

    }
}
