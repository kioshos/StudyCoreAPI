using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.Repository;

public class WordRepository : BaseRepository<Word, int>, IWordRepository
{
    public WordRepository(StudyCoreAPIContext context)
        :base(context)
    {
        
    }
    
    public override async Task UpdateAsync(Word entity)
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

    public async Task<IReadOnlyCollection<Word>> GetAllByWorkspaceIdAsync(Guid workspaceId)
    {
        return await context.Set<Word>()
            .Where(w => w.WorkspaceId == workspaceId)
            .AsNoTracking()
            .ToListAsync();
    }
}