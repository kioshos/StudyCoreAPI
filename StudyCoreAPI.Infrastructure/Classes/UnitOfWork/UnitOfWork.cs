using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Application.Interfaces;

namespace StudyCoreAPI.Infrastructure.Classes.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    public IRepository<Account, Guid> Accounts { get; }
    public IRepository<Workspace, Guid> Workspaces { get; }
    public IRepository<WorkspaceAccess, Guid> WorkspaceAccesses { get; }
    public IRepository<Word, int> Words { get; }
    public IRepository<Book, int> Books { get; }
    public IRepository<Problem, int> Problems { get; }
    
    public UnitOfWork(DbContext context, IRepository<Account, Guid> accounts, 
        IRepository<Workspace, Guid> workspaces, IRepository<WorkspaceAccess, Guid> workspaceAccesses, 
        IRepository<Word, int> words, IRepository<Book, int> books, IRepository<Problem, int> problems)
    {
        _context = context;
        Accounts = accounts;
        Workspaces = workspaces;
        WorkspaceAccesses = workspaceAccesses;
        Words = words;
        Books = books;
        Problems = problems;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task SaveChangesAsync()
    {
       await _context.SaveChangesAsync();
    }
}