using ArchiNote.Api.Extensions;
using ArchiNote.Api.Infrastructure;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.Application.Projects.Create;
using ArchiNote.SharedKernel;

namespace ArchiNote.Api.Endpoints.Projects;

public class Create : IEndpoint
{
    public sealed record Request
    {
        public string Name { get; set; }
    }
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("projects", async (
            Request request,
            ICommandHandler<CreateProjectCommand, Guid> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateProjectCommand
            {
                Name = request.Name
            };
            
            Result<Guid> result = await handler.Handle(command, cancellationToken);
            
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Projects);    
    }
}