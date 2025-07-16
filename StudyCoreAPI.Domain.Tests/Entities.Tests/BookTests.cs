using StudyCoreAPI;
namespace StudyCoreAPI.Domain.Tests;

public class BookTests 
{
    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] {0,10,0f};
        yield return new object[] {1 ,10, 0.1f};
        yield return new object[] {5 ,10, 0.5f};
    }
    
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void CompletePercentage_ShouldBeCorrect(int pageRead, 
        int pageCount, float expected)
    {
        var book = new Book
        {
            PageCount = pageCount,
            ReadPages = pageRead
        };

        var result = book.CompletePercentage;
        
        Assert.Equal(expected, result, 3);
    }
}