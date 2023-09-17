using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chronicle
{
    public interface IThemeUri
    {
        /// <summary>
        /// Merged dictionaries of this application
        /// </summary>
        Collection<ResourceDictionary> GetTheme { get; set; }
    }
}
