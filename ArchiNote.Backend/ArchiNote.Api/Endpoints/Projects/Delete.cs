using ArchiNote.Api.Extensions;
using ArchiNote.Api.Infrastructure;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.Application.Projects.Delete;

namespace ArchiNote.Api.Endpoints.Projects;

public sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("projects/{id:guid}", async (
                Guid id,
                ICommandHandler<DeleteProjectCommand> handler,
                CancellationToken cancellationToken) =>
        {
            var command =  new DeleteProjectCommand(id);
            
            var result = await handler.Handle(command, cancellationToken);
            
            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Projects);
    }
}