using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    /// <summary>
    /// Information store for client files
    /// </summary>
    public interface IClientDataStore
    {
        /// <summary>
        /// Checks if data store is null
        /// </summary>
        Task<bool> FileExists();

        /// <summary>
        /// Make sure the data store is setup correctly
        /// </summary>
        /// <returns>Returns a task that will finish once setup is complete</returns>
        Task DataStoreAvailable();

        /// <summary>
        /// Commits data to the data store
        /// </summary>
        /// <param name="file">The data to commit to the database</param>
        /// <returns>Returns a task that will finish once setup is complete</returns>
        Task SaveFile(NoteDataModel file);

        /// <summary>
        /// Gets the list of stored data from the client data store if they exist
        /// </summary>
        Task<List<NoteDataModel>> GetFiles();

        /// <summary>
        /// Removes data from the client data store if it exist
        /// </summary>
        /// <param name="file">The file to remove from the data store</param>
        Task DeleteFile(NoteDataModel file);
    }
}
