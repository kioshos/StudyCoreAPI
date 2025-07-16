using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.Repository;

public class ProblemRepository : BaseRepository<Problem, int>
{
    public ProblemRepository(StudyCoreAPIContext context)
        :base(context)
    {
        
    }
    
    public override async Task UpdateAsync(Problem entity)
    {
        var problem = await GetByIdAsync(entity.Id);

        if (problem == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        
        problem.Title = entity.Title;
        problem.IsCompleted = entity.IsCompleted;
        problem.Link = entity.Link;
        problem.Note = entity.Note;
        problem.Difficulty = entity.Difficulty;
        problem.CompletionDate = entity.CompletionDate;
    }
}