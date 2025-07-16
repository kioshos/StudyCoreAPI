using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudyCoreAPI.Infrastructure.Classes.Configurations;

public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
{
    public void Configure(EntityTypeBuilder<Problem> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Title).IsRequired();
        builder.Property(p => p.Difficulty).IsRequired();

        builder.HasOne(p => p.Workspace)
            .WithMany(w => w.Problems)
            .HasForeignKey("WorkspaceId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Account)
            .WithMany()
            .HasForeignKey("AccountId")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.ToTable("Problems");
    }
}