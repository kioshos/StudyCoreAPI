using Microsoft.AspNetCore.Identity;
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
        return await _unitOfWork.Words.GetAllAsync();
    }

    public async Task<Word> GetByIdAsync(int wordId)
    {
        var word = await _unitOfWork.Words.GetByIdAsync(wordId);

        if (word == null)
        {
            throw new KeyNotFoundException("Word not found");
        }

        return word;
    }

    public async Task AddAsync(WordDto wordDto)
    {
        var newWord = new Word()
        {
            OwnerId = wordDto.OwnerId,
            Name = wordDto.Name,
            Meaning = wordDto.Meaning,
            PartOfSpeech = wordDto.PartOfSpeech,
            Level = wordDto.Level,
            Type = wordDto.Type,
            Note = wordDto.Note,
        };
        
       await _unitOfWork.Words.AddAsync(newWord);
       
       await _unitOfWork.SaveChangesAsync();
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