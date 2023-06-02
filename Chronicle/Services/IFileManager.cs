using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Responsible for managing files for this application 
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// Normalizes path to file based on machine architecture
        /// (Windows OS / Linux OS)
        /// </summary>
        /// <param name="path">The path to normalize</param>
        /// <returns></returns>
        string NormalizePath(string path);

        /// <summary>
        /// Get the absolute path to the file
        /// </summary>
        /// <param name="fullPath">The path to resolve</param>
        string ResolvePath(string fullPath);

        /// <summary>
        /// Writes information to a file as a text
        /// </summary>
        /// <param name="message">The information to write to a file</param>
        /// <param name="fullPath">The full path to the file</param>
        /// <param name="append">Adds to an existing file if true, otherwise overrides the existing</param>
        Task WriteTextToFile(string message, string fullPath, bool append = true);

    }
}
