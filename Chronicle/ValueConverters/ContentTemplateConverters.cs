using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Takes <see cref="TabContentTemplates"/> and convert it to an actual template
    /// </summary>
    public class ContentTemplateConverters : BaseValueConverter<ContentTemplateConverters>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Sort and return the appropriate template
            switch((TabContentTemplates)value)
            {
                // Plain template
                case TabContentTemplates.Plain:
                    return new PlainContentTemplate();
                // Lined template
                case TabContentTemplates.Lined:
                    return new LinedContentTemplate();
                // Lined with margin template
                case TabContentTemplates.LinedWithMargin:
                    return new LineWithMarginTemplateControl();
            }

            return value;

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
