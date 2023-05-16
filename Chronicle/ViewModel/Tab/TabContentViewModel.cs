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

            }
        }

        /// <summary>
        /// Main content as text
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public TabContentViewModel()
        {
            // Set default properties values
            TitleLabel = "Title";
            _title = string.Empty;
            Content = string.Empty;

            // Update properties
            OnPropertyChanged(nameof(Content));
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(_title));
        }
    }
}