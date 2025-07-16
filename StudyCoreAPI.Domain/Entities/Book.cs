using Microsoft.AspNetCore.Identity;

namespace StudyCoreAPI;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Language { get; set; }
    public Workspace Workspace { get; set; }
    public int ReadPages {get; set;}
    public int PageCount {get; set;}
    public DateTime? CompleteDate {get; set;}

    public float CompletePercentage
    {
        get
        {
            if (PageCount == 0) 
                return 0;
            
            return (float)ReadPages / PageCount;
        }
    }
    public IdentityUser Account {get; set;}

    public Book()
    {
        
    }
    
}