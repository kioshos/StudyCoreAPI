namespace StudyCoreAPI.Domain.Tests;

public class WorkspaceTests
{
    
    [Fact]
    public void Constructor_ShouldAssignNewGuidId()
    {
        var workspace = new Workspace("Workspace123");
        
        Assert.NotNull(workspace.Id);
    }
}