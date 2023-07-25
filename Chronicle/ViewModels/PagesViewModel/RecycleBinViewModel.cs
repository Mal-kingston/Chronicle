using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Chronicle
{
    /// <summary>
    /// View model for the recycle bin view
    /// </summary>
    public class RecycleBinViewModel : BaseViewModel
    {
        #region Private Fields

        /// <summary>
        /// Content of select all button
        /// </summary>
        private const string _selectAllText = "Select all";

        /// <summary>
        /// The text for select all button to switch to 
        /// when all or if any item on the list are currently selected
        /// </summary>
        private const string _clearAllText = "Clear all Selection";

        /// <summary>
        /// The text for select all button
        /// </summary>
        private string _selectionButtonText = _selectAllText;

        /// <summary>
        /// The list of deleted items by the user
        /// </summary>
        private ObservableCollection<DeletedItemViewModel> _deletedItems;

        #endregion

        #region Public Properties

        /// <summary>
        /// The text for select all button
        /// </summary>
        public string SelectionButtonText 
        {
            // Get the value
            get { return _selectionButtonText; }
            set
            {
                // If value isn't same...
                if (_selectionButtonText != value)
                    // Update value
                    _selectionButtonText = value;

                // Update property
                OnPropertyChanged(nameof(SelectionButtonText));
            } 
        }

        /// <summary>
        /// True if list is empty,
        /// Otherwise false if list is not empty
        /// </summary>
        public bool IsListEmpty { get; set; }

        /// <summary>
        /// The list of deleted items by the user
        /// </summary>
        public ObservableCollection<DeletedItemViewModel> DeletedItems 
        {
            // Provide items
            get { return  _deletedItems; }
            set
            {
                // If value are same...
                if (_deletedItems == value)
                    // Do nothing 
                    return;

                // Otherwise, set value 
                _deletedItems = value;

                // Update property value
                OnPropertyChanged(nameof(DeletedItems));
            }
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// Command to SELECT OR UN_SELECT ALL the items on the list
        /// </summary>
        public ICommand SelectAllCommand { get; set; }

        /// <summary>
        /// Command to recover selected items
        /// </summary>
        public ICommand RecoverCommand { get; set; }

        /// <summary>
        /// Command to permanently delete selected items
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RecycleBinViewModel()
        {
            // Set properties defaults
            _deletedItems = new ObservableCollection<DeletedItemViewModel>();
            SelectionButtonText = _selectionButtonText!;
            IsListEmpty = false;

            if (_deletedItems.Count.Equals(0))
                IsListEmpty = true;

            // Create commands
            SelectAllCommand = new RelayCommand(SelectsOrClearsAllSelection);
            RecoverCommand = new RelayCommand(RecoverItems);
            DeleteCommand = new RelayCommand(DeleteItems);

        }

        #endregion

        #region Public Commands

        /// <summary>
        /// Selects all or clears all selection of the deleted items list
        /// </summary>
        private void SelectsOrClearsAllSelection()
        {
            // If selection mode is to select all...
            if(_selectionButtonText == _selectAllText )
            {
                // Select all item on the list
                _deletedItems?.ToList().ForEach(item => item.IsSelected = true);
                // Set mode to clear selection
                _selectionButtonText = _clearAllText;
                // Update property
                OnPropertyChanged(nameof(SelectionButtonText));
            }
            // Otherwise...
            else 
            {
                // Clear all selection
                _deletedItems?.ToList().ForEach(item => item.IsSelected = false);
                // Set mode to select all
                _selectionButtonText = _selectAllText;
                // Update property
                OnPropertyChanged(nameof(SelectionButtonText));
            }

        }

        /// <summary>
        /// Recovers only the selected items on the list
        /// </summary>
        private void RecoverItems()
        {
            var selectedItems = _deletedItems?.ToList().FindAll(item => item.IsSelected == true);
        }

        /// <summary>
        /// Deletes only the selected items on the list
        /// </summary>
        private void DeleteItems()
        {
            var selectedItems = _deletedItems?.ToList().FindAll(item => item.IsSelected == true);

        }

        #endregion

        /// <summary>
        /// Adds deleted file(s) to the deleted items list
        /// </summary>
        public void SendToRecycle()
        {
            // Make in memory data available
            var recycleItems = AccessInMemoryDb.InMemoryData;

            // Clear deleted items list
            _deletedItems.Clear();

            // Make sure in memory data isn't null
            if (recycleItems == null)
                // If it's null, Do nothing
                return;

            // Go through in memory data...
            foreach (var item in recycleItems)
            {
                // Filter items that are flagged for recycling
                if(item.Value.IsInRecycle == true)
                {
                    // Construct deleted item and set up properties
                    var itemConstruction = new DeletedItemViewModel(this)
                    {
                        ItemId = item.Key,
                        FileName = item.Value.Header,
                        DeletedDate = item.Value.AssociatedDate.ToString("d"),
                    };

                    // Add every item flagged for recycling
                    _deletedItems.Add(itemConstruction);
                }
            }

            // If we have no item on the deleted item list
            if (_deletedItems.Count.Equals(0))
                // Set empty list tag to true
                IsListEmpty = true;
            // Otherwise...
            else
                // Set list to false
                IsListEmpty = false;

            // Update properties
            OnPropertyChanged(nameof(IsListEmpty));
            OnPropertyChanged(nameof(DeletedItems));
        }

        /// <summary>
        /// Event method implementation that
        /// Changes the text on the select all | clear all text button
        /// </summary>
        /// <param name="sender">Source of the event</param>
        /// <param name="args">Argument of the event</param>
        public void OnSelectionChanged(object sender, EventArgs args)
        {
            // If any item is selected ?. Then change button text to clear all text, otherwise reset text
            _selectionButtonText = _deletedItems.Any(item => item.IsSelected == true) ? _clearAllText : _selectAllText;

            // Update property
            OnPropertyChanged(nameof(SelectionButtonText));
        }
    }
}
