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
    /// Interaction logic for ListControl.xaml
    /// </summary>
    public partial class NotesListControl : UserControl
    {
        public NotesListControl()
        {
            InitializeComponent();

        }



        public bool ShowNotesList
        {
            get { return (bool)GetValue(ShowNotesListProperty); }
            set { SetValue(ShowNotesListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowNotesList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowNotesListProperty =
            DependencyProperty.Register("ShowNotesList", typeof(bool), typeof(NotesListControl));


    }
}
