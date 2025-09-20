using ArchiNote.Api.Extensions;
using ArchiNote.Api.Infrastructure;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.Application.Users.Login;
using ArchiNote.SharedKernel;

namespace ArchiNote.Api.Endpoints.Users;

internal sealed class Login : IEndpoint
{
    public sealed record Request(string Email, string Password);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/login", async (
                Request request,
                ICommandHandler<LoginUserCommand, string> handler,
                CancellationToken cancellationToken) =>
            {
                var command = new LoginUserCommand(request.Email, request.Password);

               var result = await handler.Handle(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Users);    }
}