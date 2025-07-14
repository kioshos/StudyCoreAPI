using Microsoft.AspNetCore.Identity;

namespace StudyCoreAPI;

public class WorkspaceAccess
{
    public IdentityUser Account { get; set; }
    public Workspace Workspace { get; set; }
    public DateTime SentAt { get; set; }

    public WorkspaceAccess()
    {
        
    }
}