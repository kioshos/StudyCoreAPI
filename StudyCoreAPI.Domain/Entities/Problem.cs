using Microsoft.AspNetCore.Identity;

namespace StudyCoreAPI;

public class Problem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Difficulty { get; set; }
    public DateTime? CompletionDate { get; set; }
    public string? Link { get; set; }
    public string? Solution { get; set; }
    public bool IsCompleted { get; set; }
    public string? Note { get; set; }
    public Account Account{ get; set; }
    public Workspace Workspace { get; set; }

    public Problem()
    {
        
    }
}