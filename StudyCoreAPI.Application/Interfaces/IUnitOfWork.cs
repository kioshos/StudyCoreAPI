namespace StudyCoreAPI.Application.Interfaces;

public interface  IUnitOfWork
{
    IRepository<Account, string> Accounts { get; }
    IRepository<Workspace, Guid> Workspaces { get; }
    IRepository<WorkspaceAccess, Guid> WorkspaceAccesses { get; }
    IRepository<Word, int> Words { get; }
    IRepository<Book, int> Books { get; }
    IRepository<Problem, int> Problems { get; }
    Task SaveChangesAsync();
}