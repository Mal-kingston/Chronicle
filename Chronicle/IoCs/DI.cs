﻿using Chronicle;
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
        #region Client Data Store

        /// <summary>
        /// Shortcut to access the <see cref="IClientDataStore"/>
        /// </summary>
        public static IClientDataStore ClientDataStore => Framework.Service<IClientDataStore>();

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
        /// Shortcut to access the <see cref="TabControlViewModel"/>
        /// </summary>
        public static TabContentViewModel FileTemplateVM => Framework.Service<TabContentViewModel>();

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
        /// Shortcut to access the <see cref="TrashPage"/>
        /// </summary>
        public static TrashPage TrashPageInstance => Framework.Service<TrashPage>();

        #endregion
    }
}