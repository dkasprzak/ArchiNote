using ArchiNote.Application.Abstractions.Data;
using ArchiNote.Application.Abstractions.Handlers;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.Domain.Projects;
using ArchiNote.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace ArchiNote.Application.Projects.Delete;

internal sealed class DeleteProjectCommandHandler(IApplicationDbContext dbContext)
    : BaseCommandHandler(dbContext), ICommandHandler<DeleteProjectCommand>
{
    public async Task<Result> Handle(DeleteProjectCommand command, CancellationToken cancellationToken)
    {
        var project = await dbContext.Projects
            .SingleOrDefaultAsync(p => p.Id == command.ProjectId,  cancellationToken);

        if (project is null)
        {
            return Result.Failure(ProjectErrors.NotFound(command.ProjectId));
        }
        
        dbContext.Projects.Remove(project);
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}