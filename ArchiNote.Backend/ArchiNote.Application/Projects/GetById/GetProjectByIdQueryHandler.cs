using ArchiNote.Application.Abstractions.Data;
using ArchiNote.Application.Abstractions.Handlers;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.Domain.Projects;
using ArchiNote.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace ArchiNote.Application.Projects.GetById;

internal sealed class GetProjectByIdQueryHandler(IApplicationDbContext dbContext) :
    BaseQueryHandler(dbContext), IQueryHandler<GetProjectByIdQuery, ProjectResponse>
{
    public async Task<Result<ProjectResponse>> Handle(GetProjectByIdQuery query, CancellationToken cancellationToken)
    {
        var project = await dbContext.Projects
            .Where(p => p.Id ==  query.ProjectId)
            .Select(p =>  new ProjectResponse
            {
                Id = p.Id,
                Name = p.Name,
                Status = p.Status,
                CreatedDate = p.CreatedDate,
                ModifiedDate = p.ModifiedDate
            })
            .SingleOrDefaultAsync(cancellationToken);

        if (project is null)
        {
            return Result.Failure<ProjectResponse>(ProjectErrors.NotFound(query.ProjectId));
        }
        
        return project;
    }
}