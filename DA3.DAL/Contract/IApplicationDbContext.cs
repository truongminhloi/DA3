using DA3.DAL.Domain;
using Microsoft.EntityFrameworkCore;

namespace DA3.DAL.Contract
{
    public interface IApplicationDbContext
    {
        DbSet<Account> Accounts { get; set; }

        DbSet<Cart> Carts { get; set; }

        DbSet<CartDetails> CartDetails { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Category> Categories { get; set; }

        public DbSet<Store> Store { get; set; }

        int SaveChanges();
    }
}
