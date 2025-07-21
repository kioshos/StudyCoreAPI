using System.Collections;
using Moq;
using StudyCoreAPI.Application.DTOs;
using StudyCoreAPI.Application.Interfaces;
using StudyCoreAPI.Application.Services;

namespace StudyCoreAPI.Application.Tests.Services;

public class WordServiceTests
{
    private readonly Mock<IRepository<Word, int>> _mockWordRepository;
    
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    
    private readonly WordService _wordService;

    public WordServiceTests()
    {
        _mockWordRepository = new Mock<IRepository<Word, int>>();
        
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        
        _mockUnitOfWork.Setup(u => u.Words).Returns(_mockWordRepository.Object);
        
        _mockUnitOfWork.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);
        
        _wordService = new WordService(_mockUnitOfWork.Object);
    }

    public static WordDto GetTestWord()
    {
        var wordDto = new WordDto()
        {
            Name = "TestWord",
            Meaning = "TestMeaning",
        };
        
        return wordDto;
    }
    public static IEnumerable<object[]> WordsTestData()
    {
        yield return new object[]
        {
            new List<Word>()
            {
                new Word()
                {
                    Name = "Hello"
                },
                new Word()
                {
                    Name = "Word"
                },
                new Word(),
            }
        };

        yield return new object[]
        {
            new List<Word>()
        };
    }

    [Theory]
    [MemberData(nameof(WordsTestData))]
    public async Task GetAllAsync_WhenListIsNotEmpty_ReturnListOfWords(List<Word> expectedWords)
    {
        _mockWordRepository.Setup(w => w.GetAllAsync())
            .ReturnsAsync(expectedWords);
        
        var result = await _wordService.GetAllAsync();
        
        Assert.Equal(expectedWords, result);
    }

    [Fact]
    public async Task GetAllAsync_WhenListIsEmpty_ReturnEmptyList()
    {
        var emptyList = new List<Word>();
        _mockWordRepository.Setup(w => w.GetAllAsync())
            .ReturnsAsync(emptyList);
        
        var result = await _wordService.GetAllAsync();
        
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetByIdAsync_WhenWordExists_ReturnWord()
    {
        var wordWithId1 = new Word()
        {
            Id = 1,
        };

        _mockWordRepository.Setup(w => 
            w.GetByIdAsync(wordWithId1.Id))
            .ReturnsAsync(wordWithId1);
        
        var result = await _wordService.GetByIdAsync(wordWithId1.Id);
        
        Assert.NotNull(result);
        Assert.Equal(wordWithId1.Id, result.Id);
    }

    [Fact]
    public async Task GetByIdAsync_WhenWordDoesNotExist_ThrowException()
    {
        var nonExistentWord = 2;
        _mockWordRepository.Setup(r => r.GetByIdAsync(nonExistentWord))
            .ReturnsAsync((Word)null);
        
        await Assert.ThrowsAsync<KeyNotFoundException>(() =>
            _wordService.GetByIdAsync(nonExistentWord));
    }

    [Fact]
    public async Task AddAsync_ShouldMapDtoToEntity()
    {
        Word wordToCapture = null;
        
        _mockWordRepository.Setup(w => w.AddAsync(It.IsAny<Word>()))
            .Callback<Word>(w => wordToCapture = w);

        _mockUnitOfWork.Setup(uow => uow.Words).Returns(_mockWordRepository.Object);
        
        await _wordService.AddAsync(GetTestWord());
        
        Assert.NotNull(wordToCapture);
        Assert.Equal(GetTestWord().Name, wordToCapture.Name);
        Assert.Equal(GetTestWord().Meaning, wordToCapture.Meaning);
    }

    [Fact]
    public async Task AddAsync_ShouldCallMethod_Once()
    {
        await _wordService.AddAsync(GetTestWord());
        
        _mockWordRepository.Verify(w => w.AddAsync(It.IsAny<Word>()), Times.Once);
    }

    [Fact]
    public async Task AddAsync_AddWordAndSaveChanges()
    {
        await _wordService.AddAsync(GetTestWord());
        
        _mockWordRepository.Verify(w => w.AddAsync(It.IsAny<Word>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task AddAsync_WhenAddingNewWord_ShouldAssignTimestamp()
    {
        Word? addedWord = null;
        
        _mockWordRepository.Setup(w => w.AddAsync(It.IsAny<Word>()))
            .Callback<Word>(w => addedWord = w)
            .Returns(Task.CompletedTask);
        
        await _wordService.AddAsync(GetTestWord());
        
        Assert.NotNull(addedWord);
        Assert.True((DateTime.Now - addedWord!.CreatedOn).TotalSeconds < 1);
    }
}

