using DA3.DAL.Domain;
using Microsoft.EntityFrameworkCore;

namespace DA3.DAL.Contract
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
