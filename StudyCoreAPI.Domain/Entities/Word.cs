using Microsoft.AspNetCore.Identity;

namespace StudyCoreAPI;

public class Word
{
    public int Id { get; set; }
    public Workspace Workspace { get; set; }
    public Account Owner { get; set; }
    public string Name { get; set; }
    public string PartOfSpeech { get; set; }
    public string Meaning { get; set; }
    public string? Note { get; set; }
    public string? Translation { get; set; }
    public string Level { get; set; }
    public string Type { get; set; }
    public DateTime CreatedOn { get; set; }

    public Word()
    {
        CreatedOn = DateTime.Now;
    }
}