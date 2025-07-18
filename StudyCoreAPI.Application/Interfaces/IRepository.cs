namespace StudyCoreAPI.Application.Interfaces;

public interface IRepository<TEntity, TKey> where TEntity : class
{
    Task<IReadOnlyCollection<TEntity>> GetAllAsync();
    
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TKey id);
    Task<TEntity> GetByIdAsync(TKey id);
}