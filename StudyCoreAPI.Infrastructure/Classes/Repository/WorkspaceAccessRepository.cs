using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.Repository;

public class WorkspaceAccessRepository : BaseRepository<WorkspaceAccess, Guid>
{
    public WorkspaceAccessRepository(StudyCoreAPIContext context)
        :base(context)
    {
        
    }
}