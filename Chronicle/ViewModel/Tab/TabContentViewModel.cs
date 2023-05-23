using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// View model for tab content
    /// </summary>
    public class TabContentViewModel : BaseViewModel
    {
        /// <summary>
        /// Title of this content
        /// </summary>
        private string _title;

        /// <summary>
        /// Label for title
        /// </summary>
        public string TitleLabel { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value)
                    return;

                _title = value;

                // Set header
                if(_title.Length > 0)
                    Header = _title;
            }
        }

        /// <summary>
        /// Main content 
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Header of tab content
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public TabContentViewModel()
        {
            // Set default properties values
            TitleLabel = "Title";
            Header = "Untitled";
            _title = string.Empty;
            Content = string.Empty;

            // Update properties
            OnPropertyChanged(nameof(Content));
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Header));
            OnPropertyChanged(nameof(_title));
            
        }
    }
}