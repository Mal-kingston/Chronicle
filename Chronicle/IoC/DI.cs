using Chronicle;
using Dna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// A shorthand access class to get DI services with nice clean short code
    /// </summary>
    public static class DI
    {
        /// <summary>
        /// Shortcut to access the <see cref="MainViewModel"/>
        /// </summary>
        public static MainViewModel MainVM => Framework.Service<MainViewModel>();

        /// <summary>
        /// Shortcut to access the <see cref="TabControlViewModel"/>
        /// </summary>
        public static TabControlViewModel TabControlVM => Framework.Service<TabControlViewModel>();


        public static TabItemViewModel TabItemVM => Framework.Service<TabItemViewModel>();
        public static TabContentViewModel FileTemplateVM => Framework.Service<TabContentViewModel>();
        public static NotePage NotePageInstance => Framework.Service<NotePage>();
        public static BookPage BookPageInstance => Framework.Service<BookPage>();
        public static CalendarPage CalendarPageInstance => Framework.Service<CalendarPage>();
        public static SharePage SharePageInstance => Framework.Service<SharePage>();
        public static SettingsPage SettingsPageInstance => Framework.Service<SettingsPage>();
        public static TrashPage TrashPageInstance => Framework.Service<TrashPage>();

    }
}
