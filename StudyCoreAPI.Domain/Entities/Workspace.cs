using Microsoft.AspNetCore.Identity;

namespace StudyCoreAPI;

public class Workspace
{
    public Guid Id { get; set; }
    public IdentityUser Account { get; set; }
    public string Name { get; set; }
    
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