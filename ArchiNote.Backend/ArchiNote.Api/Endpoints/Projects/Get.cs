using ArchiNote.Api.Extensions;
using ArchiNote.Api.Infrastructure;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.Application.Projects.Get;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ArchiNote.Api.Endpoints.Projects;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("projects", async (
                IQueryHandler<GetProjectsQuery, List<ProjectResponse>> handler,
                CancellationToken cancellationToken) =>
            {
                var query = new GetProjectsQuery();
                
                var result =  await handler.Handle(query, cancellationToken);
                
                return result.Match(Results.Ok, CustomResults.Problem);
            } 
        )
        .WithTags(Tags.Projects);
    }
}