using DA3.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA3.DAL.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasMany(t => t.Products)
                .WithOne(f => f.Category)
                .HasForeignKey(t => t.CategoryId);
        }
    }
}
