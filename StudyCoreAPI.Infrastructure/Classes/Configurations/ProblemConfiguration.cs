using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudyCoreAPI.Infrastructure.Classes.Configurations;

public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
{
    public void Configure(EntityTypeBuilder<Problem> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Title).IsRequired().HasMaxLength(64);
        builder.Property(p => p.IsCompleted).HasDefaultValue(false);
        builder.HasOne(p => p.Workspace);
        builder.HasOne(p => p.Account);
        builder.ToTable("Problem");

    }
}