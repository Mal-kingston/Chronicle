using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    public class ContentTemplateConverters : BaseValueConverter<ContentTemplateConverters>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((TabContentTemplates)value)
            {
                case TabContentTemplates.Plain:
                    return new PlainContentTemplate();

                case TabContentTemplates.Lined:
                    return new LinedContentTemplate();

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
