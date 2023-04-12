using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Design-model for <see cref="SubMenuItemControl"/>
    /// </summary>
    public class SubMenuItemDesignModel : SubMenuItemViewModel
    {
        /// <summary>
        /// Single instance of this class
        /// </summary>
        public static SubMenuItemDesignModel Instance = new SubMenuItemDesignModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        public SubMenuItemDesignModel() 
        {
            // Title
            SubMenuTitle = "Embedded System Architecture";

            // Icon
            SubMenuIcon = IconType.BooksItem;
        }

    }
}
