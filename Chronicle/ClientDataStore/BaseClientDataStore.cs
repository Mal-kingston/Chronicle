using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using System;

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
        public async Task DeleteFile(NoteDataModel file)
        {
            // If such file doesn't exist...
            if (file == null)
                // Do nothing
                return;

            // Otherwise, Remove file from data store
            _DbContext.NoteData.Remove(file);

            // Save changes 
            await _DbContext.SaveChangesAsync();

        }

        /// <summary>
        /// Checks if data store is null
        /// </summary>
        /// <returns>True if database isn't null, Otherwise false.</returns>
        public async Task<bool> FileExists()
        {
            return await GetFiles() != null;
        }

        /// <summary>
        /// Gets the list of stored data from the client data store if they exist
        /// </summary>
        public Task<List<NoteDataModel>> GetFiles()
        {
            return Task.FromResult(_DbContext.NoteData.ToList()!); 
        }

        /// <summary>
        /// Commits data to the data store
        /// </summary>
        /// <param name="file">The data to commit to the database</param>
        public async Task SaveFile(NoteDataModel file)
        {
            // If we have nothing to save...
            if (file == null)
                // Do nothing
                return;

            // Go through file in the database...
            foreach(var item in _DbContext.NoteData)
            {
                // If this file is already in the database...
                if (item.Id == file.Id)
                {
                    // Update the file
                    await UpdateFile(file);
                    // Do nothing else
                    return;
                }
            }

            // Add file to data store
            _DbContext.NoteData.Add(file);

            // Save changes 
            await _DbContext.SaveChangesAsync();

        }

        /// <summary>
        /// Updates data that is already existing in the database
        /// </summary>
        /// <param name="file">The information to update to the database</param>
        public async Task UpdateFile(NoteDataModel file)
        {
            // Make sure we have infomation
            if (file == null)
                // Otherwise, do nothing
                return;

            // Get the saved data to update
            var savedData = _DbContext.NoteData.Single(data => data.Id == file.Id);

            // Pass new inforamtion
            savedData.Id = file.Id;
            savedData.Header = file.Header;
            savedData.Title = file.Title;
            savedData.Content = file.Content;

            // Commit changes
            await _DbContext.SaveChangesAsync();

        }

        #endregion

    }
}
