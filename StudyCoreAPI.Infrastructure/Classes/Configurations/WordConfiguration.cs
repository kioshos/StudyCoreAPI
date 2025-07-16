using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudyCoreAPI.Infrastructure.Classes.Configurations;

public class WordConfiguration : IEntityTypeConfiguration<Word>
{
    public void Configure(EntityTypeBuilder<Word> builder)
    {
        builder.HasKey(w => w.Id);

        builder.Property(w => w.Name).IsRequired();
        builder.Property(w => w.PartOfSpeech).IsRequired();
        builder.Property(w => w.Level).IsRequired();
        builder.Property(w => w.Type).IsRequired();

        builder.HasOne(w => w.Workspace)
            .WithMany(w => w.Words)
            .HasForeignKey("WorkspaceId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(w => w.Owner)
            .WithMany()
            .HasForeignKey("AccountId")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.ToTable("Words");
    }
}