using Moq;
using StudyCoreAPI.Application.DTOs;
using StudyCoreAPI.Application.Interfaces;
using StudyCoreAPI.Application.Services;

namespace StudyCoreAPI.Application.Tests.Services;

public class WorkspaceServiceTests
{
    private readonly Mock<IRepository<Workspace, Guid>> _mockWorkspaceRepository;
    
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    
    private readonly WorkspaceService _workspaceService;

    public static IEnumerable<object[]> WorkspacesTestData()
    {
        yield return new object[]
        {
            new List<Workspace>()
            {
                new Workspace(),
                new Workspace(),
                new Workspace()
            }
        };
        
        yield return new object[]
        {
            new List<Workspace>()
        };
    }

    public static IEnumerable<object[]> WorkspacesTestDataWithId()
    {
        var ws1 = new Workspace();
        var ws2 = new Workspace();
        
        yield return new object[] { ws1.Id, ws1 };
        yield return new object[] { ws2.Id, ws2 };
        yield return new object[] {Guid.NewGuid(), ws1};
    }
    public WorkspaceServiceTests()
    {
        _mockWorkspaceRepository = new Mock<IRepository<Workspace, Guid>>();
        
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        
        _mockUnitOfWork.Setup(u => u.Workspaces).Returns(_mockWorkspaceRepository.Object);
        
        _mockUnitOfWork.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);
        
        _workspaceService = new WorkspaceService(_mockUnitOfWork.Object);
        
    }
    
    [Theory]
    [MemberData(nameof(WorkspacesTestData))]
    public async Task GetAllAsync_WhenListIsNotEmpty_ReturnsAllWorkspaces(List<Workspace> expectedWorkspaces)
    {
        _mockWorkspaceRepository.Setup(w => w.GetAllAsync())
            .ReturnsAsync(expectedWorkspaces);
        
        var result = await _workspaceService.GetAllAsync();
        
        Assert.Equal(expectedWorkspaces, result);
    }

    [Fact]
    public async Task GetAllAsync_WhenListIsEmpty_ReturnsEmptyCollection()
    {
        var emptyList = new List<Workspace>();
        _mockWorkspaceRepository.Setup(w => w.GetAllAsync())
            .ReturnsAsync(emptyList);
        
        var result = await _workspaceService.GetAllAsync();
        
        Assert.NotNull(result);
        Assert.Empty(result);
        
    }
    
    [Theory]
    [MemberData(nameof(WorkspacesTestDataWithId))]
    public async Task GetByIdAsync_WhenWorkspaceExists_ReturnsWorkspace(Guid workspaceId, Workspace expectedWorkspace)
    {
        _mockWorkspaceRepository.Setup(w => w.GetByIdAsync(workspaceId))
            .ReturnsAsync(expectedWorkspace);

        var result = await _workspaceService.GetByIdAsync(workspaceId);

        Assert.Equal(expectedWorkspace, result);

    }
    
    [Fact]
    public async Task GetByIdAsync_WhenWorkspaceDoesNotExist_ThrowsKeyNotFoundException()
    {
        var nonExistentId = Guid.NewGuid();
        _mockWorkspaceRepository.Setup(r => r.GetByIdAsync(nonExistentId))
            .ReturnsAsync((Workspace)null);
        
        await Assert.ThrowsAsync<KeyNotFoundException>(() =>
            _workspaceService.GetByIdAsync(nonExistentId));
    }

    [Fact]
    public async Task CreateWorkspaceAsync_ShouldAddWorkspaceAndSaveChanges()
    {
        var workspaceToCreate = new WorkspaceDTO() { Name = "New Workspace", AccountId = "account_id_1" };

        _mockWorkspaceRepository.Setup(r => r.AddAsync(It.IsAny<Workspace>()))
            .Returns(Task.CompletedTask);

        _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
            .Returns(Task.CompletedTask);

        await _workspaceService.CreateWorkspaceAsync(workspaceToCreate);

        _mockWorkspaceRepository.Verify(r => r.AddAsync(It.Is<Workspace>(w => w.Name == "New Workspace" && w.AccountId == "account_id_1")), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }
    
    [Fact]
    public async Task DeleteWorkspaceAsync_WhenWorkspaceExists_DeletesAndSavesChanges()
    {
        var id = Guid.NewGuid();
        var workspace = new Workspace { Id = id };

        _mockWorkspaceRepository.Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync(workspace);
    
        _mockWorkspaceRepository.Setup(r => r.DeleteAsync(id))
            .Returns(Task.CompletedTask);

        await _workspaceService.DeleteWorkspaceAsync(id);

        _mockWorkspaceRepository.Verify(r => r.DeleteAsync(id), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }
    
    [Fact]
    public async Task DeleteWorkspaceAsync_WhenWorkspaceDoesNotExist_ThrowsKeyNotFoundException()
    {
        var id = Guid.NewGuid();

        _mockWorkspaceRepository.Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync((Workspace)null);

        await Assert.ThrowsAsync<KeyNotFoundException>(() => _workspaceService.DeleteWorkspaceAsync(id));
    }
}