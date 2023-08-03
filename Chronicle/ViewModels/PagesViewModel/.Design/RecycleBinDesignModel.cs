using System;
using System.Collections.ObjectModel;

namespace Chronicle
{
    /// <summary>
    /// Design-model class for the <see cref="RecycleBinPage"/>
    /// </summary>
    public class RecycleBinDesignModel : RecycleBinViewModel
    {
        /// <summary>
        /// The single instance of this object
        /// </summary>
        public static RecycleBinDesignModel Instance => new RecycleBinDesignModel();

        /// <summary>
        /// Default constructor
        /// </summary>
        public RecycleBinDesignModel()
        {
            // Hide the empty list tag
            IsListEmpty = false;

            // Inject dummy data into the list
            DeletedItems = new ObservableCollection<DeletedItemViewModel>
            {
                new DeletedItemViewModel(this)
                {
                    DeletedDate = DateTime.Now.Subtract(TimeSpan.FromDays(25)).ToShortDateString(),
                    FileName = "Embedded system design",
                    FileType = FileType.Book,
                    IsSelected = true,
                },

                new DeletedItemViewModel(this)
                {
                    DeletedDate = DateTime.Now.ToShortDateString(),
                    FileName = "Readers are leaders",
                    FileType = FileType.Book,
                    IsSelected = false,
                },

                new DeletedItemViewModel(this)
                {
                    DeletedDate = DateTime.Now.Subtract(TimeSpan.FromDays(13)).ToShortDateString(),
                    FileName = "Micro-electronics",
                    FileType = FileType.Book,
                    IsSelected = true,
                },

                new DeletedItemViewModel(this)
                {
                    DeletedDate = DateTime.Now.Subtract(TimeSpan.FromDays(8)).ToShortDateString(),
                    FileName = "Amazon Shopping list",
                    FileType = FileType.Note,
                    IsSelected = true,
                },

                new DeletedItemViewModel(this)
                {
                    DeletedDate = DateTime.Now.Subtract(TimeSpan.FromDays(85)).ToShortDateString(),
                    FileName = "Grocery list",
                    FileType = FileType.Note,
                    IsSelected = false,
                },

                new DeletedItemViewModel(this)
                {
                    DeletedDate = DateTime.Now.Subtract(TimeSpan.FromDays(33)).ToShortDateString(),
                    FileName = "Errands to run this weekend",
                    FileType = FileType.Note,
                    IsSelected = false,
                },

            };
        }
    }
}
