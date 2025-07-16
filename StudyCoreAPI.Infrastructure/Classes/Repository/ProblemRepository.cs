using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.Repository;

public class ProblemRepository : IRepository<Problem, int>
{
    private readonly StudyCoreAPIContext _context;
    public ProblemRepository(StudyCoreAPIContext context)
    {
        _context = context;
    }
    public async Task<IReadOnlyCollection<Problem>> GetAllAsync()
    {
        return await _context.Problems.ToArrayAsync();
    }

    public async Task AddAsync(Problem entity)
    {
       await _context.Problems.AddAsync(entity);
    }

    public async Task UpdateAsync(Problem entity)
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

    public async Task DeleteAsync(int id)
    {
        var problem = await GetByIdAsync(id);
        _context.Problems.Remove(problem);
    }

    public async Task<Problem> GetByIdAsync(int id)
    {
        return await _context.Problems.FindAsync(id);
    }
}