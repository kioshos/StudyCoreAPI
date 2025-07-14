using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudyCoreAPI.Infrastructure.Classes.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
 
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name).IsRequired();
        builder.Property(b => b.Author).IsRequired();
        builder.Property(b => b.Language).IsRequired();

        builder.HasOne(b => b.Workspace)
            .WithMany(w => w.Books)
            .HasForeignKey("WorkspaceId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(b => b.Account)
            .WithMany()
            .HasForeignKey("AccountId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Books");
    }
}