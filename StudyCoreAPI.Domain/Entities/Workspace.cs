using Microsoft.AspNetCore.Identity;

namespace StudyCoreAPI;

public class Workspace
{
    public Guid Id { get; set; }
    public string AccountId { get; set; }
    public Account Owner { get; set; }
    public string Name { get; set; }
    
    public ICollection<Book> Books { get; set; }
    public ICollection<Problem> Problems { get; set; }
    public ICollection<Word> Words { get; set; }
    public ICollection<WorkspaceAccess> AccessList { get; set; }
    
    public Workspace()
    {
        Id = Guid.NewGuid();
    }

    public Workspace(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
    
}