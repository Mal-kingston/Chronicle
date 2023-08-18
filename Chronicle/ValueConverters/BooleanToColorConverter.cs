using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chronicle
{
    /// <summary>
    /// Takes a boolean value and returns a color value based on the boolean value received
    /// </summary>
    public class BooleanToColorConverter : BaseValueConverter<BooleanToColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO: Remake this so that any color could be used

            // Return a color value
            return (bool)value ? Application.Current.FindResource("BlueBrush") : Application.Current.FindResource("WhiteBrush");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
