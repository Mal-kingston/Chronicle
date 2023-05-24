using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Responsible for the creation of files
    /// across the application
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// Creates a new file
        /// </summary>
        /// <param name="header">Unique header or Id for every file created</param>
        /// <param name="fullPath">The full path to the file</param>
        /// <param name="append"></param>
        void CreateNewFile(string header, string fullPath, bool append = true);

        /// <summary>
        /// Get the absolute path to the file
        /// </summary>
        /// <param name="fullPath">The path to resolve</param>
        string ResolveFullPath(string fullPath);
    }
}
