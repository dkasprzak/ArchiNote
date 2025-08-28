using ArchiNote.Domain.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArchiNote.Infrastructure.Organizations;

public sealed class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.CreatedDate)
            .IsRequired();
        builder.Property(o => o.ModifiedDate)
            .IsRequired();

        builder.Property(o => o.FullName)
            .IsRequired();
        builder.Property(o => o.FullName)
            .HasMaxLength(200);
        
        builder.Property(o => o.ShortName)
            .HasMaxLength(50);

    }
}