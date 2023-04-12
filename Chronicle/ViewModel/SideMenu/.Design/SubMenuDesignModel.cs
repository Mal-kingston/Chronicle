using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Design-model for list of sub menu 
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

            // Dummy sub-menu
            BookSubMenu = new ObservableCollection<SubMenuItemViewModel>
            {
                new SubMenuItemDesignModel
                {
                    SubMenuIcon = IconType.BooksItem,
                    SubMenuTitle = "Astrophysics 101",
                },
                
                new SubMenuItemDesignModel
                {
                    SubMenuIcon = IconType.BooksItem,
                    SubMenuTitle = "Genesis of People and culture",
                },

                new SubMenuItemDesignModel
                {
                    SubMenuIcon = IconType.BooksItem,
                    SubMenuTitle = "The future of A.I",
                },
                    
                new SubMenuItemDesignModel
                {
                    SubMenuIcon = IconType.BooksItem,
                    SubMenuTitle = "Beauty and the beast",
                },

                new SubMenuItemDesignModel
                {
                    SubMenuIcon = IconType.BooksItem,
                    SubMenuTitle = "The marchant ship",
                },

            };

            NoteSubMenu = new ObservableCollection<SubMenuItemViewModel>
            {
                new SubMenuItemDesignModel
                {
                    SubMenuIcon = IconType.NotesItem,
                    SubMenuTitle = "Meeting at 10 o'clock.",
                },

                new SubMenuItemDesignModel
                {
                    SubMenuIcon = IconType.NotesItem,
                    SubMenuTitle = "Grocery list",
                },

                new SubMenuItemDesignModel
                {
                    SubMenuIcon = IconType.NotesItem,
                    SubMenuTitle = "Pick up order @ 6pm",
                },

                new SubMenuItemDesignModel
                {
                    SubMenuIcon = IconType.NotesItem,
                    SubMenuTitle = "List of equipments needed in the lab",
                },

                new SubMenuItemDesignModel
                {
                    SubMenuIcon = IconType.NotesItem,
                    SubMenuTitle = "Untitled-note",
                },

            };
        }
    }
}
