using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using Repositoty;

namespace ProjectIO
{
    class EntityConfigurationCustomer : EntityTypeConfiguration<ClassCustomer>
    {
        public EntityConfigurationCustomer()
        {
            this.ToTable("Customer");
            this.HasKey<int>(c => c.customerID);
            this.Property(c => c.name)
                .HasMaxLength(150)
                .IsRequired();
            this.Property(c => c.address)
                .HasMaxLength(150)
                .IsRequired();
            this.Property(c => c.zipCity)
                .HasMaxLength(150)
                .IsRequired();
            this.Property(c => c.country)
                .HasMaxLength(70)
                .IsRequired();
            this.Property(c => c.email)
                .HasMaxLength(150)
                .IsRequired();
            this.Property(c => c.phoneNo)
                .HasMaxLength(50)
                .IsRequired();
            this.Property(c => c.maxBid)
                .HasColumnType("money")
                .IsRequired();
            this.Property(c => c.preferredCurrency)
                .HasMaxLength(3)
                .IsRequired();
        }
    }
}
