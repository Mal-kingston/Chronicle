using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    public class MenuListValueConverter : BaseValueConverter<MenuListValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((IconType)value != IconType.NotesItem || (IconType)value != IconType.BooksItem)
                return null;

            switch ((IconType)value)
            {
                case IconType.NotesItem:
                    return new NotesListControl { DataContext = new NotesListControlViewModel() };

                case IconType.BooksItem:
                    return new BooksListControl { DataContext = new BooksListControlViewModel() };

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
