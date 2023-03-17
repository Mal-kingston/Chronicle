using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// View model for the book view
    /// </summary>
    public class BookPageViewModel : BaseViewModel
    {
        public string Label { get; set; } 

        public BookPageViewModel()
        {
            Label = "BOOK PAGE UNDER CONSTRUCTION";
        }
    }
}
