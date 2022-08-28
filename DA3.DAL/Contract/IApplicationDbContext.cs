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

        DbSet<Store> Store { get; set; }

        DbSet<Favorite> Favorites { get; set; }

        DbSet<Feedback> Feedbacks { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<OrderDetails> OrderDetails { get; set; }

        int SaveChanges();
    }
}
