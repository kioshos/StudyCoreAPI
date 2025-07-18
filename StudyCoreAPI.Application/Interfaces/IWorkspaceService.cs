using StudyCoreAPI.Application.DTOs;

namespace StudyCoreAPI.Application.Interfaces;

public interface IWorkspaceService
{
    Task<IReadOnlyCollection<Workspace>> GetAllAsync();
    Task<Workspace> GetByIdAsync(Guid workspaceId);
    Task CreateWorkspaceAsync(WorkspaceDTO workspace);
    Task DeleteWorkspaceAsync(Guid workspaceId);
}