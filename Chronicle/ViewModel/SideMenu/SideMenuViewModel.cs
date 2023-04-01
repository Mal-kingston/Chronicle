using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// View model for the <see cref="SideMenuControl"/>
    /// </summary>
    public class SideMenuViewModel : BaseViewModel
    {
        /// <summary>
        /// The list of submenu of this menu
        /// </summary>
        public ObservableCollection<SubMenuDesignModel> SubMenu { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SideMenuViewModel()
        {
            // Set default properties
            SubMenu = new ObservableCollection<SubMenuDesignModel>();
        }
    }
}
