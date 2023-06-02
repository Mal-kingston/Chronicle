using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Chronicle.Services;

namespace Chronicle
{
    /// <summary>
    /// File manager base
    /// </summary>
    public class BaseFileManager : IFileManager
    {
        /// <summary>
        /// Normalizes path to file based on machine architecture
        /// (Windows OS / Linux OS)
        /// </summary>
        /// <param name="path">The path to normalize</param>
        /// <returns></returns>
        public string NormalizePath(string path)
        {
            // If we are on windows machine...
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                // Replace / with \
                path = path.Replace("/", "\\").Trim();
            else
                // Otherwise replace \ with /
                path = path.Replace("\\", "/").Trim();

            // Return normalized path
            return path;
        }

        /// <summary>
        /// Get the absolute path to the file
        /// </summary>
        /// <param name="path">The path to resolve</param>
        public string ResolvePath(string path)
        {
            // Get the absolute path 
            return Path.GetFullPath(path);
        }

        /// <summary>
        /// Writes information to a file as a text
        /// </summary>
        /// <param name="message">The information to write to a file</param>
        /// <param name="path">The full path to the file</param>
        /// <param name="append">Adds to an existing file if true, otherwise overrides the existing</param>
        public async Task WriteTextToFile(string message, string path, bool append = true)
        {
            // Normalize path
            path = NormalizePath(path);

            // Resolve path
            path = ResolvePath(path);

            await Task.Run(async () =>
            {
                // Write message to log file
                await using (var fileStream = (TextWriter)new StreamWriter(File.Open(path, append ? FileMode.Append : FileMode.Create)))
                    fileStream.Write(message);
            });
        }
    }
}
