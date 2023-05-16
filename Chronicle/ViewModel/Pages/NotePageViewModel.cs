using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// View model for the note page view
    /// </summary>
    public class NotePageViewModel : BaseViewModel
    {
        private TabContentViewModel _tabContent;

        public TabControlViewModel TabControl { get; set; }
        public TabItemViewModel TabItem { get; set; }
        public TabContentViewModel TabContent 
        {
            get { return _tabContent; }
            set
            {
                if (_tabContent == value)
                    return;

                _tabContent = value;

            }
        }

        public NotePageViewModel()
        {
            // Initialize properties
            TabContent = new TabContentViewModel();

            TabItem = new TabItemViewModel();
            
            TabControl = new TabControlViewModel
            {
                Items = new ObservableCollection<TabItemViewModel>
                {
                    TabItem
                }
            };

            // Update Properties
            OnPropertyChanged(nameof(TabItem));
            OnPropertyChanged(nameof(TabControl));
            OnPropertyChanged(nameof(TabContent));
        }
    }
}
