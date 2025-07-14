using Microsoft.AspNetCore.Identity;

namespace StudyCoreAPI;

public class Account : IdentityUser<string>
{
    public ICollection<Workspace> OwnedWorkspaces { get; set; }

    public ICollection<WorkspaceAccess> AccessibleWorkspaces { get; set; }

    public Account()
    {
        Id = Guid.NewGuid().ToString();
    }
}