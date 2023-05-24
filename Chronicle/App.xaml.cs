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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Setup the main application
            ApplicationSetup();


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
                 .Build();

            // Make sure data store is available
            await ClientDataStore.DataStoreAvailable();

        }
    }
}
