﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Chronicle
{
    /// <summary>
    /// View model for tab item control
    /// </summary>
    public class TabItemViewModel : BaseViewModel
    {
        /// <summary>
        /// Title of tab to display
        /// </summary>
        public string TabHeader { get; set; }

        /// <summary>
        /// True if tab is currently selected in the view
        /// Otherwise false
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// A command to close a tab
        /// </summary>
        public ICommand CloseTabCommand { get; set; }

        public TabItemViewModel()
        {
            IsSelected = false;

        }
    }
}
