namespace DA3.DAL.Repository
{
    public interface IBaseRepository <T> where T : class
    {
        Task<List<T>> All();

        Task Add(T item);

        //Task GetById(int Id);

        Task Remove(T item);

        Task Update(T item);
    }
}
