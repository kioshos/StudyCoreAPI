using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.Repository;

public class WorkspaceAccessRepository : IRepository<WorkspaceAccess, Guid>
{
    private readonly StudyCoreAPIContext _context;
    
    public WorkspaceAccessRepository(StudyCoreAPIContext context)
    {
        _context = context;
    }
    public async Task<IReadOnlyCollection<WorkspaceAccess>> GetAllAsync()
    {
        return await _context.WorkspaceAccesses.ToListAsync();
    }

    public async Task AddAsync(WorkspaceAccess entity)
    {
        await _context.WorkspaceAccesses.AddAsync(entity);
    }

    public async Task UpdateAsync(WorkspaceAccess entity)
    {
        _context.WorkspaceAccesses.Update(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var workspaceAccess = await GetByIdAsync(id);
        if (workspaceAccess == null)
        {
            throw new ArgumentNullException(nameof(workspaceAccess));
        }
        
        _context.WorkspaceAccesses.Remove(workspaceAccess);
    }

    public async Task<WorkspaceAccess> GetByIdAsync(Guid id)
    {
        return await _context.WorkspaceAccesses.FindAsync(id);
    }
}