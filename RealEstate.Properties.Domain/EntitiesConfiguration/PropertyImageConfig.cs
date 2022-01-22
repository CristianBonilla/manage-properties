using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Properties.Domain.Entities;

namespace RealEstate.Properties.Domain.EntitiesConfiguration
{
    /// <summary>
    /// Manages the property image entity model configuration
    /// </summary>
    class PropertyImageConfig : IEntityTypeConfiguration<PropertyImageEntity>
    {
        /// <summary>
        /// Gets the set configuration of the property image entity model
        /// </summary>
        /// <param name="builder">Property image builder</param>
        public void Configure(EntityTypeBuilder<PropertyImageEntity> builder)
        {
            builder.ToTable("PropertyImage", "dbo")
                .HasKey(key => key.PropertyId);
            builder.Property(property => property.PropertyImageId)
                .HasDefaultValueSql("NEWID()");
            builder.Property(property => property.File)
                .IsRequired();
            builder.Property(property => property.Enabled)
                .IsRequired();

            builder.HasOne(one => one.Property)
                .WithMany()
                .HasForeignKey(key => key.PropertyId);
        }
    }
}
