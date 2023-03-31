using System;
using System.Collections.Generic;
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

        public List<SubMenuDesignModel> Items { get; set; }


        /// <summary>
        /// Default constructor
        /// </summary>
        public SideMenuDesignModel()
        {
                    
            // Sub-menu
            Items = new List<SubMenuDesignModel>
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
