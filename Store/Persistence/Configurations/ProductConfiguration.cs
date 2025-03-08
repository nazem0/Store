using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> b)
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(ProductConstants.NameMaxLength);
            b.ToTable(nameof(Product));
        }
    }
}
