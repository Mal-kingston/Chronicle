﻿using Chronicle;
using Dna;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
                // Setup connection string
                options.UseSqlite("Data Source=C:\\Users\\mal\\Documents\\GitHub\\Chronicle\\Chronicle.db");
            }, contextLifetime: ServiceLifetime.Transient);

            // Inject the database
            construction.Services.AddTransient<IClientDataStore>(
                provider => new BaseClientDataStore(provider.GetService<ClientDataStoreDbContext>()));

            // Return the construction for chaining
            return construction;
        }

    }
}