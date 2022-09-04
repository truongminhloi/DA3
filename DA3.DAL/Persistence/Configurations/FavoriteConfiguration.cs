using DA3.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA3.DAL.Persistence.Configurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasKey(i => i.Id);

            //builder.HasOne(t => t.Account)
            //   .WithMany(f => f.Favorites)
            //   .HasForeignKey(f => f.UserId);

            //builder.HasOne(t => t.Product)
            //   .WithMany(f => f.Favorites)
            //   .HasForeignKey(f => f.ProductId);

            //builder.Ignore(e => e.Account);
            //builder.Ignore(e => e.Product);
        }
    }
}
