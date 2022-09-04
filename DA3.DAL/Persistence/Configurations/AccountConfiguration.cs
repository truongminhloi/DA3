using DA3.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA3.DAL.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(i => i.Id);
            //builder.HasMany(t => t.Favorites)
            //    .WithOne(f => f.Account)
            //    .HasForeignKey(t => t.UserId);

            //builder.HasOne(t => t.Cart)
            //    .WithOne(f => f.Account)
            //    .HasForeignKey<Account>(f => f.Id);

            //builder.HasOne(t => t.Order)
            //    .WithOne(f => f.Account)
            //    .HasForeignKey<Account>(f => f.Id);
        }
    }
}
