using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudyCoreAPI.Infrastructure.Classes;

public class StudyCoreAPIContext : IdentityDbContext
{
    
    public StudyCoreAPIContext(DbContextOptions<StudyCoreAPIContext> options) 
        : base(options)
    {
        
    }
    
}