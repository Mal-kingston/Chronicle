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
    public class BaseClientDataStore : IClientDataStore
    {
        #region Protected Members

        /// <summary>
        /// The database context for the client data store
        /// </summary>
        protected ClientDataStoreDbContext _DbContext { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbContext">The database to use</param>
        public BaseClientDataStore(ClientDataStoreDbContext dbContext) 
        {
            // Set properties
            _DbContext = dbContext;
        }

        #endregion

        #region Interface Implementation

        /// <summary>
        /// Make sure the data store is setup correctly
        /// </summary>
        /// <returns>Returns a task that will finish once setup is complete</returns>
        public async Task DataStoreAvailable()
        {
            // Make sure we have db.
            await _DbContext.Database.EnsureCreatedAsync();
        }

        /// <summary>
        /// Removes data from the client data store if it exist
        /// </summary>
        /// <param name="file">The file to remove from the data store</param>
        public async Task DeleteFile(FileDataModel file)
        {
            // If such file doesn't exist...
            if (file == null)
                // Do nothing
                return;

            // Otherwise, Remove file from data store
            _DbContext.FilesDataModel.Remove(file);

            // Save changes 
            await _DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if a file exists in the data store
        /// </summary>
        /// <returns>True if file exists, Otherwise false.</returns>
        public async Task<bool> FileExists()
        {
            return await GetFile() != null;
        }

        /// <summary>
        /// Gets the stored data from the client data store if it exist
        /// </summary>
        public Task<FileDataModel> GetFile()
        {
            return Task.FromResult(_DbContext.FilesDataModel.FirstOrDefault());
        }

        /// <summary>
        /// Commits data to the data store
        /// </summary>
        /// <param name="file">The data to commit to the database</param>
        /// <returns>Returns a task that will finish once setup is complete</returns>
        public async Task SaveFile(FileDataModel file)
        {
            // If we have nothing to save...
            if (file == null)
                // Do nothing
                return;

            // Otherwise, Add file to data store
            _DbContext.FilesDataModel.Add(file);

            // Save changes 
            await _DbContext.SaveChangesAsync();
        }

        #endregion

    }
}
