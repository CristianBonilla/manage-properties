using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Properties.Domain.Entities;
using RealEstate.Properties.Domain.SeedWork;

namespace RealEstate.Properties.Domain.EntitiesConfiguration
{
    /// <summary>
    /// Manages the property entity model configuration
    /// </summary>
    class PropertyConfig : IEntityTypeConfiguration<PropertyEntity>
    {
        /// <summary>
        /// Gets the set configuration of the property entity model
        /// </summary>
        /// <param name="builder">Property builder</param>
        public void Configure(EntityTypeBuilder<PropertyEntity> builder)
        {
            builder.ToTable("Property", "dbo")
                .HasKey(key => key.PropertyId);
            builder.Property(property => property.PropertyId)
                .HasDefaultValueSql("NEWID()");
            builder.Property(property => property.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            builder.Property(property => property.Address)
                .HasMaxLength(150)
                .IsUnicode()
                .IsRequired();
            builder.Property(property => property.Price)
                .HasPrecision(18, 6)
                .IsRequired();
            builder.Property(property => property.CodeInternal)
                .IsRequired();
            builder.Property(property => property.Year)
                .IsRequired();

            builder.HasOne(one => one.Owner)
                .WithMany()
                .HasForeignKey(key => key.OwnerId);

            builder.HasData(SeedData.PropertiesSeed);
        }
    }
}
