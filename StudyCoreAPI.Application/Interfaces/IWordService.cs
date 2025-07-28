using StudyCoreAPI.Application.DTOs;

namespace StudyCoreAPI.Application.Interfaces;

public interface IWordService
{
    Task<IReadOnlyCollection<Word>> GetAllByWorkspaceId(Guid workspaceId);
    
    Task<Word> GetByIdAsync(int wordId);
    
    Task AddAsync(Guid workspaceId, WordCreateDto newWordCreate);
    
    Task UpdateAsync(int id, WordUpdateDto updatedWord);
    
    Task<bool> DeleteAsync(int wordId);
}