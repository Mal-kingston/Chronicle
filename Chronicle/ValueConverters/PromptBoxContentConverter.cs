using System;
using System.Globalization;

namespace Chronicle
{
    public class PromptBoxContentConverter : BaseValueConverter<PromptBoxContentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            switch((PromptBoxContent)value)
            {
                case PromptBoxContent.SaveAndExitContent:
                    return new SaveAndExitControl { DataContext = DI.SaveAndExitPromptVM };

                case PromptBoxContent.SaveAsContent:
                    return new SaveAsControl { DataContext = DI.SaveAsPromptVM };

                default:
                    break;
            }

            return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
