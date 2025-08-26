using ArchiNote.Application.Abstractions.Data;
using ArchiNote.Application.Abstractions.Handlers;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace ArchiNote.Application.Projects.Get;

internal sealed class GetProjectsQueryHandler(IApplicationDbContext dbContext) : 
    BaseQueryHandler(dbContext), IQueryHandler<GetProjectsQuery, List<ProjectResponse>>
{
    public async Task<Result<List<ProjectResponse>>> Handle(GetProjectsQuery query, CancellationToken cancellationToken)
    {
        var projects = await dbContext.Projects
            .Select(project => new ProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                CreatedDate = project.CreatedDate,
                ModifiedDate = project.ModifiedDate
            })
            .ToListAsync(cancellationToken);
        
        return projects;
    }
}