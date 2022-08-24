using DA3.DAL.Domain;
using Microsoft.EntityFrameworkCore;

namespace DA3.DAL.Contract
{
    public interface IApplicationDbContext
    {
        DbSet<Account> Accounts { get; set; }

        int SaveChanges();
    }
}
