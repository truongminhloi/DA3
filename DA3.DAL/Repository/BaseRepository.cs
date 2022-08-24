using Microsoft.EntityFrameworkCore;

namespace DA3.DAL.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public DbSet<T> dbSet;

        public async Task<List<T>> All()
        {
            return dbSet.ToList();
        }

        public async Task Add(T item)
        {
            dbSet.Add(item);
        }

        //public async Task<List<T>> GetById(int Id)
        //{
        //    return dbSet.Find();
        //}

        public async Task Remove(T item)
        {
            dbSet.Remove(item);
        }

        public async Task Update(T item)
        {
            dbSet.Update(item);
        }
    }
}
