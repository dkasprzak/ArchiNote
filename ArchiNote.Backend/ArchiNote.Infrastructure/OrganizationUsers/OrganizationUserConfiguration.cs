using ArchiNote.Domain.OrganizationUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArchiNote.Infrastructure.OrganizationUsers;

public sealed class OrganizationUserConfiguration : IEntityTypeConfiguration<OrganizationUser>
{
    public void Configure(EntityTypeBuilder<OrganizationUser> builder)
    {
        builder.HasKey(ou => new { ou.OrganizationId, ou.UserId });
        
        builder.HasOne(o => o.Organization)
            .WithMany(o => o.OrganizationUsers)
            .HasForeignKey(o => o.OrganizationId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(o => o.User)
            .WithMany(o => o.OrganizationUsers)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}