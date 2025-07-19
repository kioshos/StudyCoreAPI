namespace StudyCoreAPI.Application.DTOs;

public record WordDto()
{
    public Guid WorkspaceId { get; init; }
    
    public string OwnerId { get; init; }
    
    public string Name { get; init; }
    
    public string PartOfSpeech { get; init; }
    
    public string Meaning { get; init; }
    
    public string? Note { get; init; }
    
    public string? Translation { get; init; }
    
    public string Level { get; init; }
    
    public string Type { get; init; }
}