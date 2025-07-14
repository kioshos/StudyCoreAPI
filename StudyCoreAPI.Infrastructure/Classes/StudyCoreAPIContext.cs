using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudyCoreAPI.Infrastructure.Classes.Configurations;

namespace StudyCoreAPI.Infrastructure.Classes;

public class StudyCoreAPIContext : IdentityDbContext
{
    public DbSet<Workspace> Workspaces { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Word> Words { get; set; }
    public DbSet<Problem> Problems { get; set; }
    
    public StudyCoreAPIContext(DbContextOptions<StudyCoreAPIContext> options) 
        : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new ProblemConfiguration());
        modelBuilder.ApplyConfiguration(new WordConfiguration());
        modelBuilder.ApplyConfiguration(new WorkspaceConfiguration());
    }
}