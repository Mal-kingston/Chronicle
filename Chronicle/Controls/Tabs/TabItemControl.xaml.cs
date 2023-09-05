using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaction logic for TabItemControl.xaml
    /// </summary>
    public partial class TabItemControl : UserControl
    {

        public TabItemControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Selection functionality for this control
        /// </summary>
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Selected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(TabItemControl), new PropertyMetadata(defaultValue: false, OnPropertyChanged));

        /// <summary>
        /// Header for each tab
        /// </summary>
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(TabItemControl), new PropertyMetadata(defaultValue: "Untitled"));

        /// <summary>
        /// Brings this control into view if its partially visible when selected.
        /// NOTE: Same applies to currently opened tabs that are not visible, 
        ///       When users tries to open them, they will be brought into view
        /// </summary>
        /// <remarks>
        /// ===  Callback for when this control is selected  ===
        /// </remarks>
        /// <param name="d">This control</param>
        /// <param name="e">The value of this control</param>
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // If latest value is true (Meaning that the tab is currently selected)...
            if ((bool)e.NewValue)
                // Bring it into view
                (d as TabItemControl)?.BringIntoView();
        }

    }
}
