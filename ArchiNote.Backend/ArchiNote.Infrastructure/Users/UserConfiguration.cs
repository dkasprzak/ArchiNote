using ArchiNote.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArchiNote.Infrastructure.Users;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName)
            .IsRequired();
        builder.Property(u => u.FirstName)
            .HasMaxLength(200);
        
        builder.Property(u => u.LastName)
            .IsRequired();
        builder.Property(u => u.LastName)
            .HasMaxLength(200);
        
        builder.Property(u => u.Email)
            .IsRequired();
        builder.Property(u => u.Email)
            .HasMaxLength(200);
        
        builder.Property(u => u.PasswordHash)
            .IsRequired();
        builder.Property(u => u.PasswordHash)
            .HasMaxLength(200);
        
        builder.Property(u => u.CreatedDate)
            .IsRequired();
        
        builder.Property(u => u.ModifiedDate)
            .IsRequired();
        
        builder.HasIndex(u => u.Email)
            .IsUnique();
        
    }
}