using Chronicle;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Controls;

using static Chronicle.DI;

namespace Chronicle
{
	/// <summary>
	/// Helper to convert and provide pages
	/// </summary>
	public static class ApplicationPageHelpers
	{
		/// <summary>
		/// Sort and provide the appropriate requested page
		/// </summary>
		/// <param name="page">The page requested</param>
		public static Page ToBasePage(this ApplicationPage page)
		{
			// Find the appropriate page
			switch(page)
			{
				// Note
				case ApplicationPage.NoteFile:
					return NotePageInstance;

				// Book
                case ApplicationPage.BookFile:
                    return new BookPage { DataContext = new BookPageViewModel() };
				
				// Calendar
				case ApplicationPage.Calendar:
                    return new CalendarPage { DataContext = new CalendarPageViewModel() };

				// Share
                case ApplicationPage.Share:
                    return new SharePage { DataContext = new SharePageViewModel() };

				// Settings
                case ApplicationPage.Settings:
                    return SettingsPageInstance;

				// Trash
                case ApplicationPage.RecycleBin:
                    return RecycleBinPageInstance;

				// Notify developer if something is wrong
                default:
                    Debugger.Break();
					return null!;
			}
		}

		public static ApplicationPage ToApplicationPage(this Page page)
		{
			// Find and return the application page that matches the base page
			if (page is NotePage)
				return ApplicationPage.NoteFile;

            if (page is BookPage)
                return ApplicationPage.BookFile;

            Debugger.Break();
			return default(ApplicationPage);
        }

	}
}
