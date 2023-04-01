using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chronicle
{
    /// <summary>
    /// Interaction logic for SideMenuControl.xaml
    /// </summary>
    public partial class SideMenuControl : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SideMenuControl()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Menu title
        /// </summary>
        public string MenuTitle
        {
            get { return (string)GetValue(MenuTitleProperty); }
            set { SetValue(MenuTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MenuTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuTitleProperty =
            DependencyProperty.Register("MenuTitle", typeof(string), typeof(SideMenuControl));

        /// <summary>
        /// Icon for each menu
        /// </summary>
        public IconType MenuIcon
        {
            get { return (IconType)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(IconType), typeof(SideMenuControl), new PropertyMetadata(defaultValue: IconType.Note));

        /// <summary>
        /// True if a menu item features a submenu
        /// otherwise false.
        /// </summary>
        public bool HasSubMenu
        {
            get { return (bool)GetValue(HasSubMenuProperty); }
            set { SetValue(HasSubMenuProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HasSubMenu.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasSubMenuProperty =
            DependencyProperty.Register("HasSubMenu", typeof(bool), typeof(SideMenuControl), new PropertyMetadata(defaultValue: (bool)false));

    }

}
