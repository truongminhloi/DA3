using DA3.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA3.DAL.Persistence.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasMany(t => t.CartDetails)
                .WithOne(f => f.Cart)
                .HasForeignKey(t => t.CartId);
        }
    }
}
