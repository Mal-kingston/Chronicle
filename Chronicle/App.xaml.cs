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

            // Log information
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
                     .AddUIManager()
                     .Build();

            // Make sure data store is available
            await ClientDataStore.DataStoreAvailable();

            // Grab a copy of the client data store
            AccessInMemoryDb.GetCopyOfDbData();

            // Populate recycle bin as needed
            AccessInMemoryDb.UpdateRecycleBin();

        }
    }
}
