using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chronicle
{
    public class PromptBoxButtonAttachedProperties : BaseAttachedProperty<PromptBoxButtonAttachedProperties, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var element = (sender as ItemsControl);

            if (element == null)
                return;

            element.Loaded += (s, e) =>
            {
                //element.Items;
            };
        }
    }
}
