namespace NZWalksDemo.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T obj);
        Task<T> UpdateAsync(Guid id, T obj);
    }
}
