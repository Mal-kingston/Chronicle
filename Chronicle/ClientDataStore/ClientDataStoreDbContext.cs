using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronicle
{
    public class ClientDataStoreDbContext : DbContext
    {
        #region DbSets

        /// <summary>
        /// The client file data entry (row in database)
        /// </summary>
        public DbSet<FileDataModel> FilesDataModel { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ClientDataStoreDbContext(DbContextOptions<ClientDataStoreDbContext> options) : base(options) { }

        #endregion

        #region Model Creating

        /// <summary>
        /// Configures the database structure and relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Files data model
            // --------------------------
            //
            // Set Id as primary key
            modelBuilder.Entity<FileDataModel>().HasKey(x => x.Id);

        }

        #endregion

    }
}
