using Dna;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Documents;

namespace Chronicle
{
    /// <summary>
    /// Extension methods for <see cref="FrameworkConstruction"/>
    /// </summary>
    public static class FrameworkConstructionExtensions
    {
        /// <summary>
        /// Injects view model instances as needed for the application
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddViewModels(this FrameworkConstruction construction)
        {
            // Inject singleton instances of view models
            construction.Services.AddSingleton<MainViewModel>();
            construction.Services.AddSingleton<TabControlViewModel>();
            construction.Services.AddSingleton<TabItemViewModel>();
            construction.Services.AddSingleton<TabContentViewModel>();
            construction.Services.AddSingleton<NotePageViewModel>();
            construction.Services.AddSingleton<SubMenuViewModel>();
            construction.Services.AddSingleton<BasicPromptViewModel>();
            construction.Services.AddSingleton<SaveAsPromptViewModel>();
            construction.Services.AddSingleton<RecycleBinViewModel>();

            // Return the construction for chaining
            return construction;

        }

        /// <summary>
        /// Injects page instances as needed for the application
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddPages(this FrameworkConstruction construction)
        {
            // Inject singleton instances of pages
            construction.Services.AddSingleton<NotePage>();
            construction.Services.AddSingleton<BookPage>();
            construction.Services.AddSingleton<CalendarPage>();
            construction.Services.AddSingleton<SharePage>();
            construction.Services.AddSingleton<SettingsPage>();
            construction.Services.AddSingleton<RecycleBinPage>();

            // Return the construction for chaining
            return construction;
        }

        /// <summary>
        /// Injects client data store for the application
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddClientDataStore(this FrameworkConstruction construction)
        {
            // Inject SQLite EF data store
            construction.Services.AddDbContext<ClientDataStoreDbContext>(options =>
            {
                // TODO: Use configuration locate file/folder using app-settings.json file

                // Get the folder where database will be created and stored
                var pathToLogFile = GetFullPathToFile(@"Database\Chronicle.db");

                // Setup connection string
                options.UseSqlite($"Data Source={pathToLogFile}");
            }, contextLifetime: ServiceLifetime.Transient);

            // Inject the database
            construction.Services.AddTransient<IClientDataStore>(
                provider => new BaseClientDataStore(provider.GetService<ClientDataStoreDbContext>()!));

            // Return the construction for chaining
            return construction;
        }

        /// <summary>
        /// Injects logging system 
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddLoggers(this FrameworkConstruction construction)
        {
            // TODO: Use configuration locate file/folder using app-settings.json file

            // Get the folder where log file will be created and stored
            var pathToLogFile = GetFullPathToFile(@"logs\Chronicle-log.txt");

            // Add log factory
            construction.Services.AddTransient<ILogFactory>(logs => new LogFactory(new ILogger[] { new FileLogger(pathToLogFile) }));

            // Return the construction for chaining
            return construction;
        }

        /// <summary>
        /// Inject file manager
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddFileManager(this FrameworkConstruction construction)
        {
            // Add file manager
            construction.Services.AddTransient<IFileManager>(fileManage => new BaseFileManager());

            // Return the construction for chaining
            return construction;
        }

        /// <summary>
        /// Inject UI manager
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddUIManager(this FrameworkConstruction construction)
        {
            // Add UI manager
            construction.Services.AddScoped<IUIManager>(UI => new UIManager());

            // Return the construction for chaining
            return construction;
        }

        #region Temporary Helpers

        /// <summary>
        /// Temporary function that points to the services directory of this application
        /// to create and locate files for utilization 
        /// 
        /// ============================================================================
        /// NOTE: Remove this function, once configuration is setup and in use
        /// ============================================================================
        /// 
        /// </summary>
        /// <param name="path">The path to services folder</param>
        /// <returns>Full path to the services folder</returns>
        public static string GetFullPathToFile(string path)
        {
            // Get the absolute path
            var absolutePath = Directory.GetDirectories(Directory.GetCurrentDirectory().Replace(@"\\", @"\")).ToList();

            // Copy of full path a string
            var absolutePathCopy = absolutePath[0];

            // Tracks instances of folders named chronicle
            var trackInstancesOfChronicleFolder = 0;

            // Pointer to the services folder
            var pathToServicesFolder = string.Empty;
            
            // While we have full path...
            while(absolutePath != null)
            {
                // if we can't find service folder
                if(pathToServicesFolder.EndsWith(@":\"))
                {
                    // Let developer know
                    Debugger.Break();
                    // Exit this loop
                    break;
                }

                // Extract folder name from absolute path
                pathToServicesFolder = Path.GetDirectoryName(absolutePathCopy);

                // Adjust path to re-check for the services folder
                absolutePathCopy = pathToServicesFolder;

                // If the instance of the folder we are looking for is found...
                if (pathToServicesFolder!.EndsWith("Chronicle") && trackInstancesOfChronicleFolder == 1)
                    // Exit loop
                    break;

                // If first instance of the folder is found, Ignore 
                if (pathToServicesFolder!.EndsWith("Chronicle") && trackInstancesOfChronicleFolder == 0)
                    // And update tracking variable
                    trackInstancesOfChronicleFolder = 1;

            }

            // Return the folder where folder / file will be created and stored
            return Path.GetFullPath(Path.Combine($@"{pathToServicesFolder}\Services\", path));
        }

        #endregion

    }
}