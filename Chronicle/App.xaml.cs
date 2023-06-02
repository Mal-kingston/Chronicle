using Dna;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static Chronicle.DI;

namespace Chronicle
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Manually handle application starting up
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Setup the main application
            ApplicationSetup();

            // Log inforamtion
            Logger.Log("Application services setup completed.");

            // Show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
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
                 .Build();

            // Make sure data store is available
            await ClientDataStore.DataStoreAvailable();

        }
    }
}
