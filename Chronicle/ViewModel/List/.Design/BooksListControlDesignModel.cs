using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Chronicle
{
    /// <summary>
    /// Design model for the Books list control 
    /// </summary>
    public class BooksListControlDesignModel : BooksListControlViewModel
    {
        /// <summary>
        /// A single instance of this class
        /// </summary>
        public static BooksListControlDesignModel Instance => new BooksListControlDesignModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        public BooksListControlDesignModel()
        {
            // Dummy data
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

            };
        }

    }
}
