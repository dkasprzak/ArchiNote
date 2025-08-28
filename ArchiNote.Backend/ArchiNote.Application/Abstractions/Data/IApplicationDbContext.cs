using ArchiNote.Domain.Organizations;
using ArchiNote.Domain.OrganizationUsers;
using ArchiNote.Domain.Projects;
using ArchiNote.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ArchiNote.Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<Project> Projects { get; }
    DbSet<User> Users { get; }
    DbSet<Organization> Organizations { get; }
    DbSet<OrganizationUser> OrganizationUsers { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}