using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// File manager base
    /// </summary>
    public class BaseFileManager : IFileManager
    {
        /// <summary>
        /// Creates a new file
        /// </summary>
        /// <param name="header">Unique header or Id for every file created</param>
        /// <param name="fullPath">The full path to the file</param>
        /// <param name="append"></param>
        public void CreateNewFile(string header, string fullPath, bool append = true)
        {

        }

        /// <summary>
        /// Get the absolute path to the file
        /// </summary>
        /// <param name="fullPath">The path to resolve</param>
        public string ResolveFullPath(string fullPath)
        {
            // Resolve path to absolute
            return Path.GetFullPath(fullPath);
        }
    }
}
