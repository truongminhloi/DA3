using DA3.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA3.DAL.Persistence.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasOne(t => t.Order)
               .WithMany(f => f.OrderDetails)
               .HasForeignKey(f => f.OrderId);

            //builder.HasOne(t => t.Product)
            //   .WithMany(f => f.OrderDetails)
            //   .HasForeignKey(f => f.ProductId);

            builder.Ignore(e => e.Order);
            //builder.Ignore(e => e.Product);
        }
    }
}
