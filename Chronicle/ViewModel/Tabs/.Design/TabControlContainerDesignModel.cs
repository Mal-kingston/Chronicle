using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Chronicle
{
    /// <summary>
    /// Design model for the tab control container
    /// </summary>
    public class TabControlContainerDesignModel : TabControlContainerViewModel
    {
        /// <summary>
        /// A single instance of this class
        /// </summary>
        public static TabControlContainerDesignModel Instance => new TabControlContainerDesignModel();

        public TabControlContainerDesignModel() 
        {
            Items = new ObservableCollection<TabControlViewModel>
            {
                new TabControlViewModel
                {
                    TabHeader = "Notes for .Net",
                    IsSelected = true,
                },

            };
        }
    }
}
