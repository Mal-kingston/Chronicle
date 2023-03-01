using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// View model for the container of the side menu control
    /// </summary>
    public class MenuButtonParentDesignModel : MenuButtonParentViewModel
    {
        /// <summary>
        /// A single instance of this class
        /// </summary>
        public static MenuButtonParentDesignModel Instance => new MenuButtonParentDesignModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        public MenuButtonParentDesignModel()
        {
            TopMenuItems = new ObservableCollection<MenuButtonViewModel>()
            {
                new MenuButtonViewModel()
                {
                    MenuIcon = IconType.Note,
                    MenuTitle = "Note",
                    NotesSubMenu = new ObservableCollection<NotesListControlViewModel>
                    {
                        new NotesListControlViewModel()
                        {
                            NoteListItems = new ObservableCollection<ListControlItemViewModel>
                            {
                                new ListControlItemViewModel
                                {
                                    FileName = "Walk the dog after work.",
                                    Icon = IconType.NotesItem
                                },

                                new ListControlItemViewModel
                                {
                                    FileName = "Grocery list.",
                                    Icon = IconType.NotesItem
                                },

                                new ListControlItemViewModel
                                {
                                    FileName = "Tasks to complete at work.",
                                    Icon = IconType.NotesItem
                                },

                                new ListControlItemViewModel
                                {
                                    FileName = "Meeting at 10am with CEO.",
                                    Icon = IconType.NotesItem
                                },

                                new ListControlItemViewModel
                                {
                                    FileName = "This year meditation session times.",
                                    Icon = IconType.NotesItem
                                },

                                new ListControlItemViewModel
                                {
                                    FileName = "Gym membership code.",
                                    Icon = IconType.NotesItem
                                },
                            }
                        }
                    }
                },

                new MenuButtonViewModel()
                {
                    MenuIcon = IconType.Book,
                    MenuTitle = "Book",
                    BooksSubMenu = new ObservableCollection<BooksListControlViewModel>
                    {
                        new BooksListControlViewModel()
                        {
                            BookListItems = new ObservableCollection<ListControlItemViewModel>
                            {
                                new ListControlItemViewModel
                                {
                                    FileName = "Microcontroller 101.",
                                    Icon = IconType.BooksItem
                                },

                                new ListControlItemViewModel
                                {
                                    FileName = "Healthy Life Style.",
                                    Icon = IconType.BooksItem
                                },

                                new ListControlItemViewModel
                                {
                                    FileName = "Embedded System Architecture.",
                                    Icon = IconType.BooksItem
                                },

                                new ListControlItemViewModel
                                {
                                    FileName = "Computer Architecture.",
                                    Icon = IconType.BooksItem
                                },

                                new ListControlItemViewModel
                                {
                                    FileName = "Illusion Of Time.",
                                    Icon = IconType.BooksItem
                                },

                                new ListControlItemViewModel
                                {
                                    FileName = "Cosmic tales.",
                                    Icon = IconType.BooksItem
                                },
                            }
                        }
                    }
                },

                new MenuButtonViewModel()
                {
                    MenuIcon = IconType.Calendar,
                    MenuTitle = "Calendar",
                },

                new MenuButtonViewModel()
                {
                    MenuIcon = IconType.Share,
                    MenuTitle = "Share"
                },

            };

            BottomMenuItems = new ObservableCollection<MenuButtonViewModel>()
            {
                new MenuButtonViewModel()
                {
                    MenuIcon = IconType.Settings,
                    MenuTitle = "Settings"
                },

                new MenuButtonViewModel()
                {
                    MenuIcon = IconType.Trash,
                    MenuTitle = "Trash"
                },
            };
        }
    }
}
