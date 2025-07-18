using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.Repository;

public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class
{
    protected readonly StudyCoreAPIContext context;
    
    public BaseRepository(StudyCoreAPIContext context)
    {
        this.context = context;
    }
    
    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().AsNoTracking().ToListAsync();
    }
    
    public async Task AddAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
    }

    public virtual Task UpdateAsync(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        return Task.CompletedTask;
    }

    public virtual async Task DeleteAsync(TKey id)
    {
        var entityToDelete = await GetByIdAsync(id);
        
        if (entityToDelete == null)
            throw new ArgumentNullException(nameof(entityToDelete));

        context.Set<TEntity>().Remove(entityToDelete);
    }
    
    public async Task<TEntity> GetByIdAsync(TKey id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }
}