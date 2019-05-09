using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Repositoty;

namespace ProjectIO
{
    public class WorldArtSaleContext : DbContext
    {
        public WorldArtSaleContext() : base("WorldArtSaleEksamen")
        {
            //Database.SetInitializer(new WorldArtSaleSeedInitializer());
        }

        //DbSets representing the tables of the database.
        public DbSet<ClassArt> ArtTable { get; set; }
        public DbSet<ClassCustomer> Customer { get; set; }
        public DbSet<ClassSalesValues> ArtTrade { get; set; }

        /// <summary>
        /// Overridden Method.
        /// Adds configurations to the Entities.
        /// </summary>
        /// <param name="modelBuilder">DbModelBuilder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EntityConfigurationArt());
            modelBuilder.Configurations.Add(new EntityConfigurationArtTrade());
            modelBuilder.Configurations.Add(new EntityConfigurationCustomer());
            base.OnModelCreating(modelBuilder);
        }
    }
}
