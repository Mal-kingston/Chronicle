using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Chronicle
{
    public class IsFocusedAttachedProperties : BaseAttachedProperty<IsFocusedAttachedProperties, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (sender as FrameworkElement);

            if (control == null)
                return;

            control.Loaded += (s, e) =>
            {
                control.Focus();
            };
        }
    }
}
