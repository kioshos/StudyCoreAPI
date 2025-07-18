using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.UnitOfWork;

public class UnitOfWork(StudyCoreAPIContext context,
    IRepository<Account, string> accounts,
    IRepository<Workspace, Guid> workspaces,
    IRepository<WorkspaceAccess, Guid> workspaceAccesses,
    IRepository<Word, int> words,
    IRepository<Book, int> books,
    IRepository<Problem, int> problems) : IUnitOfWork
{
    public IRepository<Account, string> Accounts { get; } = accounts;
    public IRepository<Workspace, Guid> Workspaces { get; } = workspaces;
    public IRepository<WorkspaceAccess, Guid> WorkspaceAccesses { get; } = workspaceAccesses;
    public IRepository<Word, int> Words { get; } = words;
    public IRepository<Book, int> Books { get; } = books;
    public IRepository<Problem, int> Problems { get; } = problems;
    
    public async Task SaveChangesAsync()
    {
        using (var transaction = await context.Database.BeginTransactionAsync())
        {
            try
            {
                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}