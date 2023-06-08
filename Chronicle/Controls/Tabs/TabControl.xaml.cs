using System.Windows.Controls;
using static Chronicle.DI;

namespace Chronicle
{
    /// <summary>
    /// Interaction logic for TabControl.xaml
    /// </summary>
    public partial class TabControl : UserControl
    {
        public TabControl()
        {
            InitializeComponent();

            // Set data context
            DataContext = TabControlVM;

        }

    }
}
