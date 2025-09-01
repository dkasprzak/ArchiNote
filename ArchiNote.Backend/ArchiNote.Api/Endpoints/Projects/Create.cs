using ArchiNote.Api.Extensions;
using ArchiNote.Api.Infrastructure;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.Application.Projects.Create;
using ArchiNote.Domain.Projects;
using ArchiNote.SharedKernel;

namespace ArchiNote.Api.Endpoints.Projects;

internal sealed class Create : IEndpoint
{
    public sealed record Request
    {
        public string Name { get; set; }
        public ProjectStatus Status { get; set; }
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
                Name = request.Name,
                Status = request.Status
            };
            
            var result = await handler.Handle(command, cancellationToken);
            
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Projects);    
    }
}