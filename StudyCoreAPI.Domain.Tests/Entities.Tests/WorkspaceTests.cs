namespace StudyCoreAPI.Domain.Tests;

public class WorkspaceTests
{
    
    [Fact]
    public void Constructor_ShouldAssignNewGuidId()
    {
        var workspace = new Workspace(Guid.NewGuid().ToString());
        
        Assert.NotNull(workspace.Id);
    }
}