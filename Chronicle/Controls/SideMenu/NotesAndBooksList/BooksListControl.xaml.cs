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
    /// Interaction logic for BooksListControl.xaml
    /// </summary>
    public partial class BooksListControl : UserControl
    {
        public BooksListControl()
        {
            InitializeComponent();
        }

        public bool ShowBooksList
        {
            get { return (bool)GetValue(ShowBooksListProperty); }
            set { SetValue(ShowBooksListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowBooksList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowBooksListProperty =
            DependencyProperty.Register("ShowBooksList", typeof(bool), typeof(BooksListControl));
    }
}
