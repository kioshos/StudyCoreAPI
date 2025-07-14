using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudyCoreAPI.Infrastructure.Classes.Configurations;

public class WorkspaceConfiguration : IEntityTypeConfiguration<Workspace>
{
    public void Configure(EntityTypeBuilder<Workspace> builder)
    {
        builder.HasKey(w => w.Id);
        builder.HasOne(w => w.Account);
        builder.Property(w => w.Name).IsRequired().HasMaxLength(64);
        builder.ToTable("Workspaces");
    }
}