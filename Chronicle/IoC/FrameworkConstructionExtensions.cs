using Chronicle;
using Dna;
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
        /// Injects the instances as needed for the application
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

    }
}
