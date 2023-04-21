using Dna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// A shorthand access class to get DI services with nice clean short code
    /// </summary>
    public static class DI
    {
        /// <summary>
        /// Shortcut to access the <see cref="MainViewModel"/>
        /// </summary>
        public static MainViewModel MainVM => Framework.Service<MainViewModel>();

        /// <summary>
        /// Shortcut to access the <see cref="TabControlViewModel"/>
        /// </summary>
        public static TabControlViewModel TabControlVM => Framework.Service<TabControlViewModel>();

    }
}
