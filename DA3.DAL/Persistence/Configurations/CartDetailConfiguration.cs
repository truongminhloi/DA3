using DA3.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA3.DAL.Persistence.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasOne(t => t.Cart)
               .WithMany(f => f.CartDetails)
               .HasForeignKey(f => f.CartId);

            //builder.HasOne(t => t.Product)
            //  .WithMany(f => f.CartDetails)
            //  .HasForeignKey(f => f.ProductId);

            builder.Ignore(e => e.Cart);
            //builder.Ignore(e => e.Product);
        }
    }
}
