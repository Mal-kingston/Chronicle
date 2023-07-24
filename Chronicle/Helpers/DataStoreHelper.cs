using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Input;
using static Chronicle.DI;

namespace Chronicle
{
    /// <summary>
    /// Clones and stores the client database data
    /// </summary>
    ///
    ///
    /// TODO: Channel all database transaction through this class
    public static class AccessInMemoryDb
    {
        /// <summary>
        /// The in memory store for our cloned data
        /// </summary>
        public static IDictionary<Guid, NoteDataModel>? InMemoryData { get; set; } = new Dictionary<Guid, NoteDataModel>();

        /// <summary>
        /// Call to update data in the recycle bin
        /// </summary>
        public static void UpdateRecycleBin() => RecycleVM.SendToRecycle();

        /// <summary>
        /// Gets a copy of the datastore's data
        /// </summary>
        public static async void GetCopyOfDbData()
        {
            // Clear the store of any data residue
            InMemoryData?.Clear();

            // Clone the date store
            var rawData = await ClientDataStore.GetFiles();

            // If data is null
            if (rawData == null)
                // Do nothing
                return;

            // Go through the raw data
            foreach (var data in rawData)
            {
                // If our cloned store is null...
                if (InMemoryData == null)
                    // Do nothing
                    return;

                // If we don't already have data with this id in the in memory store...
                if (!InMemoryData.ContainsKey(data.Id))
                    // Then add them to the store
                    InMemoryData?.Add(data.Id, data);
            }

        }

        /// <summary>
        /// Sets up data for recycling
        /// </summary>
        /// <param name="recycleItem">The item to recycle</param>
        public static async void ProcessAndDataForRecycling(KeyValuePair<Guid, NoteDataModel>? recycleItem)
        {
            // Make sure the item isn't null
            if (recycleItem == null)
                // Do nothing if it is null
                return;

            // Get the item raw data from database
            var dataInRecycle = (await ClientDataStore.GetFiles()).FirstOrDefault(item => item.Id == recycleItem.Value.Key);

            // If we have the data
            if(dataInRecycle != null)
            {
                // Flag it
                dataInRecycle.IsInRecycle = true;

                // Set date of this event
                dataInRecycle.AssociatedDate = DateTime.Now;
            }

            // Update the item after flagging it
            await ClientDataStore.UpdateFile(dataInRecycle!);

            // Update in memory data with changes made
            GetCopyOfDbData();

            // Send the item to recycle
            RecycleVM.SendToRecycle();
        }

    }
}
