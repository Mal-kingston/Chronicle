using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// View model for the share view
    /// </summary>
    public class SharePageViewModel : BaseViewModel
    {
        public string Label { get; set; } 

        public SharePageViewModel()
        {
            Label = "SHARE PAGE UNDER CONSTRUCTION";
        }
    }
}
