using Chronicle;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Controls;

namespace Chronicle
{

	public static class ApplicationPageHelpers
	{
		public static Page ToBasePage(this ApplicationPage page)
		{
			// Find the appropriate page
			switch(page)
			{
				case ApplicationPage.NoteFile:
					return new NotePage { DataContext = new NotePageViewModel() };

                case ApplicationPage.BookFile:
                    return new BookPage { DataContext = new BookPageViewModel() };
				
				case ApplicationPage.Calendar:
                    return new CalendarPage { DataContext = new CalendarPageViewModel() };

                case ApplicationPage.Share:
                    return new SharePage { DataContext = new SharePageViewModel() };

                case ApplicationPage.Settings:
                    return new SettingsPage { DataContext = new SettingsPageViewModel() };

                case ApplicationPage.Trash:
                    return new TrashPage { DataContext = new TrashPageViewModel() };

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
