using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Design-model for <see cref="SideMenuControl"/>
    /// </summary>
    public class SideMenuDesignModel : SideMenuViewModel
    {
        /// <summary>
        /// Single instance of this class
        /// </summary>
        public static SideMenuDesignModel Instance = new SideMenuDesignModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        public SideMenuDesignModel()
        {

            // Sub-menu
            SubMenu = new ObservableCollection<SubMenuDesignModel>
            {
                new SubMenuDesignModel
                {
                    SubMenuIcon = IconType.BooksItem,
                    SubMenuTitle = "Astrophysics 101",
                },
                
                new SubMenuDesignModel
                {
                    SubMenuIcon = IconType.BooksItem,
                    SubMenuTitle = "Genesis of People and culture",
                },

                new SubMenuDesignModel
                {
                    SubMenuIcon = IconType.BooksItem,
                    SubMenuTitle = "The future of A.I",
                },

                new SubMenuDesignModel
                {
                    SubMenuIcon = IconType.BooksItem,
                    SubMenuTitle = "Beauty and the beast",
                },

                new SubMenuDesignModel
                {
                    SubMenuIcon = IconType.BooksItem,
                    SubMenuTitle = "The marchant ship",
                },

            };
        }
    }
}
