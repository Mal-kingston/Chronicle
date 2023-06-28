using Dna;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Linq;

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
            construction.Services.AddSingleton<PromptQueryViewModel>();

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
            construction.Services.AddSingleton<TrashPage>();

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
                // TODO: Use configuration locate file/folder using appsettings.json file

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
            // TODO: Use configuration locate file/folder using appsettings.json file

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
            construction.Services.AddSingleton<IUIManager>(UI => new UIManager());

            // Return the construction for chaining
            return construction;
        }

        #region Helpers

        /// <summary>
        /// Temporary function that points to the services directory of this application
        /// to create and locate files for utilization 
        /// 
        /// -----------------------------------------------------------------------------
        /// NOTE: Remove this function, once configuration is setup and in use
        /// 
        /// </summary>
        /// <param name="path">The path to services folder</param>
        /// <returns>Full path to the services folder</returns>
        public static string GetFullPathToFile(string path)
        {
            // Get the absolute path
            var absolutePath = Directory.GetDirectories(Directory.GetCurrentDirectory());

            // Navigate to the folder where file will be created and stored
             return Path.GetFullPath(Path.Combine(absolutePath.ToString()!, $@"..\..\..\..\..\Services\{path}"));
        }

        #endregion

    }
}