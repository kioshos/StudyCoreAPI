using Microsoft.AspNetCore.Identity;

namespace StudyCoreAPI;

public class WorkspaceAccess
{
    public string AccountId { get; set; }
    public Account Account { get; set; }

    public Guid WorkspaceId { get; set; }
    public Workspace Workspace { get; set; }
    
    public DateTime SentAt { get; set; }

    public WorkspaceAccess()
    {
        
    }
}