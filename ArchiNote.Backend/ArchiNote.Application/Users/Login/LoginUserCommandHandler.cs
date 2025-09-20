using ArchiNote.Application.Abstractions.Authentication;
using ArchiNote.Application.Abstractions.Data;
using ArchiNote.Application.Abstractions.Handlers;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.Domain.Users;
using ArchiNote.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace ArchiNote.Application.Users.Login;

internal sealed class LoginUserCommandHandler(IApplicationDbContext dbContext, IPasswordManager passwordManager, ITokenProvider tokenProvider)
    : BaseCommandHandler(dbContext), ICommandHandler<LoginUserCommand, string>
{
    public async Task<Result<string>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Email == command.Email, cancellationToken);
        
        if (user is null)
        {
            return Result.Failure<string>(UserErrors.NotFoundByEmail);
        }
        
        var verified = passwordManager.VerifyPassword(user.PasswordHash,  command.Password);

        if (!verified)
        {
            return Result.Failure<string>(UserErrors.NotFoundByEmail);
        }

        var token = tokenProvider.Create(user);

        return token;
    }
}