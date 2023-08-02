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
        #region Services

        /// <summary>
        /// Shortcut to access the <see cref="IClientDataStore"/>
        /// </summary>
        public static IClientDataStore ClientDataStore => Framework.Service<IClientDataStore>();

        /// <summary>
        /// Shortcut to access the <see cref="ILogFactory"/>
        /// </summary>
        public static ILogFactory Logger => Framework.Service<ILogFactory>();

        /// <summary>
        /// Shortcut to access the <see cref="IFileManager"/>
        /// </summary>
        public static IFileManager FileManager => Framework.Service<IFileManager>();

        /// <summary>
        /// Shortcut to access the <see cref="IUIManager "/>
        /// </summary>
        public static IUIManager UIManager => Framework.Service<IUIManager>();


        #endregion

        #region ViewModels

        /// <summary>
        /// Shortcut to access the <see cref="MainViewModel"/>
        /// </summary>
        public static MainViewModel MainVM => Framework.Service<MainViewModel>();

        /// <summary>
        /// Shortcut to access the <see cref="TabControlViewModel"/>
        /// </summary>
        public static TabControlViewModel TabControlVM => Framework.Service<TabControlViewModel>();

        /// <summary>
        /// Shortcut to access the <see cref="TabControlViewModel"/>
        /// </summary>
        public static NotePageViewModel NotePageVM => Framework.Service<NotePageViewModel>();

        /// <summary>
        /// Shortcut to access the <see cref="TabItemViewModel"/>
        /// </summary>
        public static TabItemViewModel TabItemVM => Framework.Service<TabItemViewModel>();

        /// <summary>
        /// Shortcut to access the <see cref="TabContentViewModel"/>
        /// </summary>
        public static TabContentViewModel TabContentVM => Framework.Service<TabContentViewModel>();

        /// <summary>
        /// Shortcut to access the <see cref="SubMenuViewModel"/>
        /// </summary>
        public static SubMenuViewModel SubMenuVM => Framework.Service<SubMenuViewModel>();

        /// <summary>
        /// Shortcut to access the <see cref="BasicPromptViewModel"/>
        /// </summary>
        public static BasicPromptViewModel BasicPromptVM => Framework.Service<BasicPromptViewModel>();

        /// <summary>
        /// Shortcut to access the <see cref="SaveAsPromptViewModel"/>
        /// </summary>
        public static SaveAsPromptViewModel SaveAsPromptVM => Framework.Service<SaveAsPromptViewModel>();

        /// <summary>
        /// Shortcut to access the <see cref="RecycleBinViewModel"/>
        /// </summary>
        public static RecycleBinViewModel RecycleVM => Framework.Service<RecycleBinViewModel>();

        #endregion

        #region Pages

        /// <summary>
        /// Shortcut to access the <see cref="NotePage"/>
        /// </summary>
        public static NotePage NotePageInstance => Framework.Service<NotePage>();

        /// <summary>
        /// Shortcut to access the <see cref="BookPage "/>
        /// </summary>
        public static BookPage BookPageInstance => Framework.Service<BookPage>();

        /// <summary>
        /// Shortcut to access the <see cref="CalendarPage"/>
        /// </summary>
        public static CalendarPage CalendarPageInstance => Framework.Service<CalendarPage>();

        /// <summary>
        /// Shortcut to access the <see cref="SharePage"/>
        /// </summary>
        public static SharePage SharePageInstance => Framework.Service<SharePage>();

        /// <summary>
        /// Shortcut to access the <see cref="SettingsPage"/>
        /// </summary>
        public static SettingsPage SettingsPageInstance => Framework.Service<SettingsPage>();

        /// <summary>
        /// Shortcut to access the <see cref="RecycleBinPage"/>
        /// </summary>
        public static RecycleBinPage RecycleBinPageInstance => Framework.Service<RecycleBinPage>();

        #endregion
    }
}
