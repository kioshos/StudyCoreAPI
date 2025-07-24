using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyCoreAPI.Application.DTOs;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class WorkspaceController : ControllerBase
{
    private readonly IWorkspaceService _workspaceService;
    
    public WorkspaceController(IWorkspaceService workspaceService)
    {
        _workspaceService = workspaceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetWorkspacesAsync()
    {
       var allWorkspaces =  await _workspaceService.GetAllAsync();
        
        return Ok(allWorkspaces);
    }
    
    [HttpGet("{workspaceId}")]
    public async Task<IActionResult> GetWorkspaceByIdAsync(Guid workspaceId)
    {
        var workspaces =  await _workspaceService.GetByIdAsync(workspaceId);

        if (workspaces == null)
        {
            return NotFound();
        }
        
        return Ok(workspaces);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkspacesAsync(string workspaceName)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var workspaceRequest = new WorkspaceDto()
        {
            Name = workspaceName,
            AccountId = userId
        };
        
        await _workspaceService.CreateWorkspaceAsync(workspaceRequest);
        
        return Ok();
    }
}