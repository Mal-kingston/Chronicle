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
    /// Interaction logic for PlainContentTemplate.xaml
    /// </summary>
    public partial class PlainContentTemplate : UserControl
    {
        public PlainContentTemplate()
        {
            InitializeComponent();

            var number = new TextBlock
            {
                Focusable = false,
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 40, Foreground = (Brush)Application.Current.FindResource("GrayBrush"),
                FontSize = (double)Application.Current.FindResource("XSmall"),
                FontFamily = (FontFamily)Application.Current.FindResource("JostFont"),
                LineHeight = (double)Application.Current.FindResource("Small"),
                TextAlignment = TextAlignment.Center,
                // Text = 1.ToString(),
            };

            if(MainContent.LineCount < 0)
                LineNumber.Children.Add(number);

            MainContent.TextChanged += (s, e) =>
            {
                //if (MainContent.LineCount > LineNumber.Children.Count)
                //    LineNumber.Children.Add(new TextBlock
                //    {
                //        HorizontalAlignment = HorizontalAlignment.Left,
                //        Width = 40, Focusable = false,
                //        Foreground = (Brush)Application.Current.FindResource("GrayBrush"),
                //        FontSize = (double)Application.Current.FindResource("XSmall"),
                //        FontFamily = (FontFamily)Application.Current.FindResource("JostFont"),
                //        LineHeight = (double)Application.Current.FindResource("Small"),
                //        TextAlignment = TextAlignment.Center,
                //        Text = MainContent.LineCount.ToString(),
                //    });
                //else
                //{
                //    if(!(MainContent.LineCount <= 1))
                //        LineNumber.Children.RemoveAt(MainContent.LineCount);
                //}
            };

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

            Loaded += (s, e) =>
            {
                if (Title.Text.Length > 0)
                {
                    MainContent.Focus();
                    MainContent.CaretIndex = MainContent.Text.Length;
                }
                else
                {
                    Title.Focus();
                    Title.CaretIndex = MainContent.Text.Length;
                }

            };
        }
    }
}
