using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// View model for <see cref="SubMenuItemViewModel"/>
    /// </summary>
    public class SubMenuItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The title of a submenu item
        /// </summary>
        public string SubMenuTitle { get; set; }

        /// <summary>
        /// The icon type of a submenu item
        /// </summary>
        public IconType SubMenuIcon { get; set; }


    }
}
