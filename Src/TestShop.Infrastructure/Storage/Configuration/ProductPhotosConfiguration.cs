using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestShop.Domain.Entities;

namespace TestShop.Infrastructure.Storage.Configuration
{
    public class ProductPhotosConfiguration : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("product_photos");

            builder.Property(x => x.CreationDate).HasColumnType("timestamptz").HasColumnName("creation_date");
            builder.Property(x => x.Small).HasColumnType("bytea").HasColumnName("small");
            builder.Property(x => x.Medium).HasColumnType("bytea").HasColumnName("medium");
            builder.Property(x => x.Large).HasColumnType("bytea").HasColumnName("large");
        }
    }
}