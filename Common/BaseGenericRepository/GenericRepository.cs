
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : BaseEntity
{
    public async Task<int> CreateAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        return await context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        return await context.SaveChangesAsync();
    }

    public Task<IQueryable<T>> GetAllAsync()
    {
        return Task.FromResult(context.Set<T>().Where(x => !x.IsDeleted));
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await context.Set<T>().Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> UpdateAsync(T entity)
    {
        context.Set<T>().Update(entity);
        return await context.SaveChangesAsync();
    }
}