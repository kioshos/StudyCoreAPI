using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudyCoreAPI.Infrastructure.Classes.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasMany(a => a.OwnedWorkspaces)
            .WithOne(w => w.Owner)
            .HasForeignKey(w => w.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.AccessibleWorkspaces)
            .WithOne(wa => wa.Account)
            .HasForeignKey(wa => wa.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}