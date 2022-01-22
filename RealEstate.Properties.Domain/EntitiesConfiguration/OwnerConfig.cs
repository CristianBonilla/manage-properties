using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Properties.Domain.Entities;

namespace RealEstate.Properties.Domain.EntitiesConfiguration
{
    /// <summary>
    /// Manages the owner entity model configuration
    /// </summary>
    class OwnerConfig : IEntityTypeConfiguration<OwnerEntity>
    {
        /// <summary>
        /// Gets the set configuration of the owner entity model
        /// </summary>
        /// <param name="builder">Owner builder</param>
        public void Configure(EntityTypeBuilder<OwnerEntity> builder)
        {
            builder.ToTable("Owner", "dbo")
                .HasKey(key => key.OwnerId);
            builder.Property(property => property.OwnerId)
                .HasDefaultValueSql("NEWID()");
            builder.Property(property => property.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            builder.Property(property => property.Address)
                .HasMaxLength(150)
                .IsUnicode()
                .IsRequired();
            builder.Property(property => property.Photo)
                .IsRequired();
            builder.Property(property => property.Birthday)
                .IsRequired();
        }
    }
}
