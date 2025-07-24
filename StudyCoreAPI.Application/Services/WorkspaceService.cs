using StudyCoreAPI.Application.DTOs;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Application.Services;

public class WorkspaceService : IWorkspaceService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public WorkspaceService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;    
    }
    
    public async Task<IReadOnlyCollection<Workspace>> GetAllAsync()
    {
        return await _unitOfWork.Workspaces.GetAllAsync();
    }

    public async Task<Workspace> GetByIdAsync(Guid workspaceId)
    {
        
       var workspace = await _unitOfWork.Workspaces.GetByIdAsync(workspaceId);
       
       if (workspace == null)
       {
           throw new KeyNotFoundException("Workspace not found");
       }
       
       return workspace;
    }

    public async Task CreateWorkspaceAsync(WorkspaceDto workspaceDto)
    {
        var workspace = new Workspace()
        {
            Name = workspaceDto.Name,
            AccountId = workspaceDto.AccountId
        };
        
        await _unitOfWork.Workspaces.AddAsync(workspace);
        
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteWorkspaceAsync(Guid workspaceId)
    {
        var workspace = await _unitOfWork.Workspaces.GetByIdAsync(workspaceId);
        
        if (workspace == null)
        {
            throw new KeyNotFoundException();
        }
        
        await _unitOfWork.Workspaces.DeleteAsync(workspace.Id);
        
        await _unitOfWork.SaveChangesAsync();
    }
}