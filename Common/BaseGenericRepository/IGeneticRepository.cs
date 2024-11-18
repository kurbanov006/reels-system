public interface IGenericRepository<T>
{
    Task<int> CreateAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(T entity);
    Task<T?> GetByIdAsync(int id);
    Task<IQueryable<T>> GetAllAsync();
}