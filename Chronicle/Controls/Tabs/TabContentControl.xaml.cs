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
    /// Interaction logic for NoteFileControl.xaml
    /// </summary>
    public partial class TabContentControl : UserControl
    {
        public TabContentControl()
        {
            InitializeComponent();

            PreviewKeyDown += (s, e) =>
            {

                if (Keyboard.IsKeyDown(Key.Tab) && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)) && Title.IsFocused == false)
                    Title.Focus();
                else if ((Keyboard.IsKeyDown(Key.Tab) || Keyboard.IsKeyDown(Key.Enter)) && MainContent.IsFocused == false)
                    MainContent.Focus();
                else
                {
                    e.Handled = false;
                    return;
                }

                e.Handled = true;
            };
        }

    }
}
