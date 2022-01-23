using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Properties.Domain.Entities;
using RealEstate.Properties.Domain.SeedWork;

namespace RealEstate.Properties.Domain.EntitiesConfiguration
{
    /// <summary>
    /// Manages the property trace entity model configuration
    /// </summary>
    class PropertyTraceConfig : IEntityTypeConfiguration<PropertyTraceEntity>
    {
        /// <summary>
        /// Gets the set configuration of the property trace entity model
        /// </summary>
        /// <param name="builder">Property trace builder</param>
        public void Configure(EntityTypeBuilder<PropertyTraceEntity> builder)
        {
            builder.ToTable("PropertyTrace", "dbo")
                .HasKey(key => key.PropertyTraceId);
            builder.Property(property => property.PropertyTraceId)
                .HasDefaultValueSql("NEWID()");
            builder.Property(property => property.DateSale)
                .IsRequired();
            builder.Property(property => property.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            builder.Property(property => property.Value)
                .HasPrecision(18, 6)
                .IsRequired();
            builder.Property(property => property.Tax)
                .HasPrecision(18, 6)
                .IsRequired();

            builder.HasOne(one => one.Property)
                .WithMany()
                .HasForeignKey(key => key.PropertyId);

            builder.HasData(SeedData.PropertyTracesSeed);
        }
    }
}
