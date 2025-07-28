namespace StudyCoreAPI.Application.Interfaces;

public interface IWordRepository
{
    Task<IReadOnlyCollection<Word>> GetAllByWorkspaceIdAsync(Guid workspaceId);
}