namespace StudyCoreAPI.Application.Interfaces;

public interface  IUnitOfWork : IDisposable
{
    IRepository<Account, Guid> Accounts { get; }
    IRepository<Workspace, Guid> Workspaces { get; }
    IRepository<WorkspaceAccess, Guid> WorkspaceAccesses { get; }
    IRepository<Word, int> Words { get; }
    IRepository<Book, int> Books { get; }
    IRepository<Problem, int> Problems { get; }
    Task SaveChangesAsync();
}