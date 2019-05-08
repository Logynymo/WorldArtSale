using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using Repositoty;

namespace ProjectIO
{
    class EntityConfigurationArtTrade : EntityTypeConfiguration<ClassSalesValues>
    {
        public EntityConfigurationArtTrade()
        {
            this.ToTable("ArtTrade");
            this.HasKey<int>(a => a.id);
            this.Property(a => a.customerID)
                .IsRequired();
            this.Property(a => a.artID)
                .IsRequired();
            this.Property(a => a.customersBidUSD)
                .HasColumnType("money")
                .IsRequired();
            this.Property(a => a.customersBidEUR)
                .HasColumnType("money")
                .IsRequired();
            this.Property(a => a.customersBidOwnValuta)
                .HasColumnType("money")
                .IsRequired();
            this.Property(a => a.priceWithFeesUSD)
                .HasColumnType("money")
                .IsRequired();
            this.Property(a => a.priceWithFeesEUR)
                .HasColumnType("money")
                .IsRequired();
            this.Property(a => a.priceWithFeesOwnValuta)
                .HasColumnType("money")
                .IsRequired();
            this.Property(a => a.date)
                .IsRequired();

        }
    }
}
