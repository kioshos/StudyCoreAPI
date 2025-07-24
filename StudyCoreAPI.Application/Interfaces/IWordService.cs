using StudyCoreAPI.Application.DTOs;

namespace StudyCoreAPI.Application.Interfaces;

public interface IWordService
{
    Task<IReadOnlyCollection<Word>> GetAllAsync();
    
    Task<Word> GetByIdAsync(int wordId);
    
    Task AddAsync(WordDto newWord);
    
    Task UpdateAsync(WordDto updatedWord);
    
    Task DeleteAsync(int wordId);
}