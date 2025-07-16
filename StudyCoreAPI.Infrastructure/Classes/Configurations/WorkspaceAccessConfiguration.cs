using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudyCoreAPI.Infrastructure.Classes.Configurations;

public class WorkspaceAccessConfiguration : IEntityTypeConfiguration<WorkspaceAccess>
{
    public void Configure(EntityTypeBuilder<WorkspaceAccess> builder)
    {
        builder.HasKey(w => new { w.AccountId, w.WorkspaceId });

        builder.HasOne(w => w.Account)
            .WithMany(u => u.AccessibleWorkspaces)
            .HasForeignKey(w => w.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(w => w.Workspace)
            .WithMany(w => w.AccessList)
            .HasForeignKey(w => w.WorkspaceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}