using DA3.DAL.Contract;
using DA3.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DA3.DAL
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }

        public override int SaveChanges()
        {
            var result = base.SaveChanges();

            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
