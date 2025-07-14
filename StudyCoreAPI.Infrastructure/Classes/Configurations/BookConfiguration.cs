using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudyCoreAPI.Infrastructure.Classes.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
 
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);  
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(b => b.Name).HasMaxLength(50).IsRequired();
        builder.Property(b => b.Author).IsRequired();
        builder.Property(b => b.Language).HasMaxLength(50).IsRequired();
        builder.HasOne(b => b.Workspace);
        builder.Property(b => b.ReadPages).HasDefaultValue(0);
        builder.Property(b => b.PageCount).IsRequired();
        builder.HasOne(b => b.Account);
        builder.ToTable("Books");

    }
}