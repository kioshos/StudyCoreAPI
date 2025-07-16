using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.Repository;

public class WordRepository : IRepository<Word, int>
{
    private readonly StudyCoreAPIContext _context;
    public WordRepository(StudyCoreAPIContext context)
    {
        _context = context;
    }
    public async Task<IReadOnlyCollection<Word>> GetAllAsync()
    {
        return await _context.Words.ToListAsync();
    }

    public async Task AddAsync(Word entity)
    {
        await _context.Words.AddAsync(entity);
    }

    public async Task UpdateAsync(Word entity)
    {
        var word = await GetByIdAsync(entity.Id);
        word.Level = entity.Level;
        word.Name = entity.Name;
        word.Meaning = entity.Meaning;
        word.Note = entity.Note;
        word.Translation = entity.Translation;
        word.Type = entity.Type;
        word.PartOfSpeech = entity.PartOfSpeech;
    }

    public async Task DeleteAsync(int id)
    {
        var word = await _context.Words.FindAsync(id);
        
        if (word == null)
        {
            throw new ArgumentNullException(nameof(word));
        }
        _context.Words.Remove(word);
    }

    public async Task<Word> GetByIdAsync(int id)
    {
       return await _context.Words.FindAsync(id);
    }
}