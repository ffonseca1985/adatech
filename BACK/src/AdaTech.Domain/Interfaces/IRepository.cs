
namespace AdaTech.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetFirstAsync(Func<T, bool> funcFilter);
        Task<IEnumerable<T>> GetAsync(Func<T, bool> funcFilter);
        Task<IEnumerable<T>> GetAllAsync();
        Task InsertAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task DeleteAsync(object id);
        Task SaveChangesAsync();
    }
}
