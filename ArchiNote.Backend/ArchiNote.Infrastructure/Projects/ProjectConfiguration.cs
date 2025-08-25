using ArchiNote.Domain.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArchiNote.Infrastructure.Projects;

public sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Name)
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(p => p.CreatedDate)
            .IsRequired();
        
        builder.Property(p => p.ModifiedDate)
            .IsRequired();
    }
}