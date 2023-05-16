using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Chronicle
{
    /// <summary>
    /// Design model for the tab control
    /// </summary>
    public class TabControlDesignModel : TabControlViewModel
    {
        /// <summary>
        /// A single instance of this class
        /// </summary>
        public static TabControlDesignModel Instance => new TabControlDesignModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        public TabControlDesignModel() 
        {
            // Set default tab item in the view (dummy item)
            //Items = new ObservableCollection<TabItemViewModel> 
            //{
            //    new TabItemViewModel
            //    { 
            //        TabHeader = "Untitled", 
            //        IsSelected = true,
            //    }  
            //};

        }

    }
}
