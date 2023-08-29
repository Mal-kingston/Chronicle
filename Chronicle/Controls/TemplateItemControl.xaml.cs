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
    /// Interaction logic for TemplateItemControl.xaml
    /// </summary>
    public partial class TemplateItemControl : UserControl
    {
        public TemplateItemControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Thumbnail of template item
        /// </summary>
        public ImageSource TemplateThumbnail
        {
            get { return (ImageSource)GetValue(TemplateThumbnailProperty); }
            set { SetValue(TemplateThumbnailProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TemplateThumbnail.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TemplateThumbnailProperty =
            DependencyProperty.Register("TemplateThumbnail", typeof(ImageSource), typeof(TemplateItemControl));

        /// <summary>
        /// Name of label of template
        /// </summary>
        public string TemplateName
        {
            get { return (string)GetValue(TemplateNameProperty); }
            set { SetValue(TemplateNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TemplateName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TemplateNameProperty =
            DependencyProperty.Register("TemplateName", typeof(string), typeof(TemplateItemControl));

    }

}
