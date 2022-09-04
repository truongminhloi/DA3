using DA3.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA3.DAL.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(t => t.Category)
               .WithMany(f => f.Products)
               .HasForeignKey(f => f.CategoryId);

            builder.Ignore(e => e.Category);
        }
    }
}
