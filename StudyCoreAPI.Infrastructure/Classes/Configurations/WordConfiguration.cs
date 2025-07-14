using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudyCoreAPI.Infrastructure.Classes.Configurations;

public class WordConfiguration : IEntityTypeConfiguration<Word>
{
    public void Configure(EntityTypeBuilder<Word> builder)
    {
        builder.HasKey(wd => wd.Id);
        builder.Property(wd => wd.Id).ValueGeneratedOnAdd();
        builder.HasOne(wd => wd.Workspace);
        builder.HasOne(wd => wd.Account);
        builder.Property(wd => wd.Name).HasMaxLength(64).IsRequired();
        builder.Property(wd => wd.Meaning).IsRequired();
        builder.Property(wd => wd.Level).IsRequired();
        builder.Property(wd => wd.Type).IsRequired();
        builder.Property(wd => wd.CreatedOn).HasDefaultValue(DateTime.Now);
        builder.ToTable("Word");
    }
}