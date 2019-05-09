using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using Repositoty;

namespace ProjectIO
{
    class EntityConfigurationArt : EntityTypeConfiguration<ClassArt>
    {
        /// <summary>
        /// Code-First. This sets the Table to which the data gets written to.
        /// it then sets the key and properties.
        /// </summary>
        public EntityConfigurationArt()
        {
            this.ToTable("ArtTable");
            this.HasKey<int>(a => a.id);
            this.Property(a => a.picturePath)
                .HasMaxLength(4000)
                .IsRequired();
            this.Property(a => a.pictureDescription)
                .HasMaxLength(4000)
                .IsRequired();
            this.Property(a => a.pictureTitel)
                .HasMaxLength(75)
                .IsRequired();
        }
    }
}
