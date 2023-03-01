using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Chronicle.DI;


namespace Chronicle
{
    /// <summary>
    /// View model for the container of the side menu control
    /// </summary>
    public class MenuButtonParentViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Menu items aligned at the top
        /// </summary>
        public ObservableCollection<MenuButtonViewModel> TopMenuItems { get; set; }

        /// <summary>
        /// Menu items aligned at the bottom
        /// </summary>
        public ObservableCollection<MenuButtonViewModel> BottomMenuItems { get; set; }


        #endregion

       
    }
}
