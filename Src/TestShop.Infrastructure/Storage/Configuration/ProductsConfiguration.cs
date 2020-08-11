using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestShop.Domain.Entities;

namespace TestShop.Infrastructure.Storage.Configuration
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id).HasName("product_id");

            builder.HasIndex(x => x.CreationDate).HasName("creation_date_idx");

            builder.Property(x => x.Name).HasColumnType("varchar(64)").HasColumnName("name");
            builder.Property(x => x.Description).HasColumnType("text").HasColumnName("description");
            builder.Property(x => x.Amount).HasColumnType("money").HasColumnName("amount");
            builder.Property(x => x.PhotoId).HasColumnType("uuid").HasColumnName("picture_id");
            builder.Property(x => x.CreationDate).HasColumnType("timestamptz").HasColumnName("creation_date");

            builder.ToTable("products");
        }
    }
}