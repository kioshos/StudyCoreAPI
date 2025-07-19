using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.Repository;

public class WorkspaceRepository : BaseRepository<Workspace, Guid>
{
    public WorkspaceRepository(StudyCoreAPIContext context)
        :base(context)
    {
        
    }
    
    public override async Task UpdateAsync(Workspace entity)
    {
        var workspace = await GetByIdAsync(entity.Id);
        
        workspace.Name = entity.Name;
    }

    public override async Task<Workspace> GetByIdAsync(Guid id)
    {
        return await context.Workspaces.FirstOrDefaultAsync(w => w.Id == id);
    }
}