using ArchiNote.Application.Abstractions.Data;
using ArchiNote.Application.Abstractions.Handlers;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.Domain.Projects;
using ArchiNote.SharedKernel;

namespace ArchiNote.Application.Projects.Create;

internal sealed class CreateProjectCommandHandler(IApplicationDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : BaseCommandHandler(dbContext, dateTimeProvider), ICommandHandler<CreateProjectCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
    {
        var project = new Project
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            CreatedDate = dateTimeProvider.UtcNow,
            ModifiedDate = dateTimeProvider.UtcNow
        };
        
        dbContext.Projects.Add(project);
        
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return project.Id;
    }
}