using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chronicle
{
    public class HotkeysAttachedProperties : BaseAttachedProperty<HotkeysAttachedProperties, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var element = (sender as FrameworkElement);

            if (element == null)
                return;

            element.KeyDown += (s, e) =>
            {

            };
        }
    }
}
