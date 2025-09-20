using ArchiNote.Application.Abstractions.Messaging;

namespace ArchiNote.Application.Users.Login;

public sealed record LoginUserCommand(string Email, string Password) : ICommand<string>;
