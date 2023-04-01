using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Design-model for <see cref="SubMenuControl"/>
    /// </summary>
    public class SubMenuDesignModel : SubMenuViewModel
    {
        /// <summary>
        /// Single instance of this class
        /// </summary>
        public static SubMenuDesignModel Instance = new SubMenuDesignModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        public SubMenuDesignModel() 
        {
            // Title
            SubMenuTitle = "Embedded System Architecture";

            // Icon
            SubMenuIcon = IconType.BooksItem;
        }

    }
}
