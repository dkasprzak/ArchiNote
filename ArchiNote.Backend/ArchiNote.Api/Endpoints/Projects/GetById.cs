using ArchiNote.Api.Extensions;
using ArchiNote.Api.Infrastructure;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.Application.Projects.GetById;

namespace ArchiNote.Api.Endpoints.Projects;

public sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("project/{id:guid}", async (
                    Guid id,
                    IQueryHandler<GetProjectByIdQuery, ProjectResponse> handler,
                    CancellationToken cancellationToken) =>
                {
                    var command = new GetProjectByIdQuery(id);
                    
                    var result = await handler.Handle(command, cancellationToken);
                    
                    return  result.Match(Results.Ok, CustomResults.Problem);
                }
            )
            .WithTags(Tags.Projects);
    }
}