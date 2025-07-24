namespace StudyCoreAPI.Application.DTOs;

public sealed record WorkspaceDto
{
    public string AccountId { get; init; }
    public string Name { get; init; }
    
}