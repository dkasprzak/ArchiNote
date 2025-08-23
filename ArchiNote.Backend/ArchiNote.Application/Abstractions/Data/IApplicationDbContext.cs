using ArchiNote.Domain.Projects;
using Microsoft.EntityFrameworkCore;

namespace ArchiNote.Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<Project> Projects { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}