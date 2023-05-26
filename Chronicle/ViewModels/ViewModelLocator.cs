﻿using static Chronicle.DI;

namespace Chronicle
{
    /// <summary>
    /// Locates view model from the IoC for the use in binding for the Xaml files
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Properties

        /// <summary>
        /// Singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// The main application view model
        /// </summary>
        public MainViewModel LocateMainVM => MainVM;

        /// <summary>
        /// The view model for the tab control
        /// </summary>
        public TabControlViewModel LocateTabControlVM => TabControlVM;

        /// <summary>
        /// The view model for the tab item
        /// </summary>
        public TabItemViewModel LocateTabItemVM => TabItemVM;

        #endregion
    }
}