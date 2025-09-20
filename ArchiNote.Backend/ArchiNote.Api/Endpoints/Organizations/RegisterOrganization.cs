using ArchiNote.Api.Extensions;
using ArchiNote.Api.Infrastructure;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.Application.Organizations.RegisterOrganization;

namespace ArchiNote.Api.Endpoints.Organizations;

internal sealed class RegisterOrganization : IEndpoint
{
    public sealed record RegisterOrganizationRequest
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password{ get; set; }
        public string ConfirmPassword{ get; set; }
    }
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("register-organization", async (
                RegisterOrganizationRequest request,
                ICommandHandler<RegisterOrganizationCommand, Guid> handler,
                CancellationToken cancellationToken
            ) =>
            {
                var command = new RegisterOrganizationCommand
                {
                    FullName = request.FullName,
                    ShortName = request.ShortName,
                    Email = request.Email,
                    ConfirmEmail = request.ConfirmEmail,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Password = request.Password,
                    ConfirmPassword = request.ConfirmPassword
                };
                
                var result = await handler.Handle(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Auth);
    }
}