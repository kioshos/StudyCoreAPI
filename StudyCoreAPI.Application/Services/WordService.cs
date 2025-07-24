using StudyCoreAPI.Application.DTOs;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Application.Services;

public class WordService : IWordService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public WordService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IReadOnlyCollection<Word>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Word> GetByIdAsync(int wordId)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(WordDto newWord)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(WordDto updatedWord)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int wordId)
    {
        throw new NotImplementedException();
    }
}