using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.Repository;

public class WorkspaceRepository : IRepository<Workspace, Guid>
{
    private readonly StudyCoreAPIContext _context;
    
    public WorkspaceRepository(StudyCoreAPIContext context)
    {
        _context = context;
    }
    public async Task<IReadOnlyCollection<Workspace>> GetAllAsync()
    {
        return await _context.Workspaces.ToListAsync();
    }

    public async Task AddAsync(Workspace entity)
    {
        await _context.Workspaces.AddAsync(entity);
    }

    public async Task UpdateAsync(Workspace entity)
    {
        var workspace = await GetByIdAsync(entity.Id);
        
        workspace.Name = entity.Name;
    }

    public async Task DeleteAsync(Guid id)
    {
        var workspace = await GetByIdAsync(id);
        
        if (workspace == null)
        {
            throw new ArgumentNullException(nameof(workspace));
        }
        
        _context.Workspaces.Remove(workspace);
    }

    public async Task<Workspace> GetByIdAsync(Guid id)
    {
        return await _context.Workspaces.FindAsync(id);
    }
}