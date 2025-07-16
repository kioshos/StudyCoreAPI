using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.Repository;

public class AccountRepository : IRepository<Account, string>
{
    private readonly StudyCoreAPIContext _context;

    public AccountRepository(StudyCoreAPIContext context)
    {
        _context = context;
    }
    
    public async Task<IReadOnlyCollection<Account>> GetAllAsync()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task AddAsync(Account entity)
    {
        await _context.Accounts.AddAsync(entity);
    }

    public async Task UpdateAsync(Account entity)
    {
         _context.Accounts.Update(entity);
    }

    public async Task DeleteAsync(string id)
    {
        var entityToDelete = await GetByIdAsync(id);

        if (entityToDelete == null)
        {
            throw new ArgumentNullException(nameof(entityToDelete));
        }
        
        _context.Accounts.Remove(entityToDelete);
    }

    public async Task<Account> GetByIdAsync(string id)
    {
        return await _context.Accounts.FindAsync(id);
    }
}