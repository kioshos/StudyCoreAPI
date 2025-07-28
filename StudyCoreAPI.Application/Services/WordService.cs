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

    public async Task<IReadOnlyCollection<Word>> GetAllByWorkspaceId(Guid workspaceId)
    {
        var workspace = await _unitOfWork.Workspaces.GetByIdAsync(workspaceId);

        if (workspace == null)
            throw new KeyNotFoundException($"Workspace with ID {workspaceId} not found.");

        if (_unitOfWork.Words is IWordRepository wordRepository)
            return await wordRepository.GetAllByWorkspaceIdAsync(workspaceId);

        throw new InvalidOperationException("Words repository does not implement IWordRepository.");
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

    public async Task AddAsync(Guid workspaceId, WordCreateDto wordDto)
    {
        var newWord = new Word()
        {
            WorkspaceId = workspaceId,
            AccountId = wordDto.OwnerId,
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

    public async Task UpdateAsync(int id, WordUpdateDto updatedWord)
    {
        var word = await _unitOfWork.Words.GetByIdAsync(id);
    
        if (word == null)
        {
            throw new KeyNotFoundException("Word not found");
        }
        
        word.Name = updatedWord.Name;
        word.Meaning = updatedWord.Meaning;
        word.PartOfSpeech = updatedWord.PartOfSpeech;
        word.Note = updatedWord.Note;
        
        await _unitOfWork.Words.UpdateAsync(word);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int wordId)
    {
        var word = await _unitOfWork.Words.GetByIdAsync(wordId);
        
        if (word == null)
            return false;

        await _unitOfWork.Words.DeleteAsync(word.Id);
        await _unitOfWork.SaveChangesAsync();
        
        return true;
    }
}