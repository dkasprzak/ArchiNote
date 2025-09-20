using ArchiNote.Application.Abstractions.Authentication;
using ArchiNote.Application.Abstractions.Data;
using ArchiNote.Application.Abstractions.Handlers;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.Domain.Organizations;
using ArchiNote.Domain.OrganizationUsers;
using ArchiNote.Domain.Users;
using ArchiNote.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace ArchiNote.Application.Organizations.RegisterOrganization;

internal sealed class RegisterOrganizationCommandHandler(IApplicationDbContext dbContext, IDateTimeProvider dateTimeProvider, IPasswordManager passwordManager) 
    : BaseCommandHandler(dbContext, dateTimeProvider), 
    ICommandHandler<RegisterOrganizationCommand, Guid>
{
    public async Task<Result<Guid>> Handle(RegisterOrganizationCommand command, CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine($"DbContext is null: {dbContext == null}");
            Console.WriteLine($"Users DbSet is null: {dbContext?.Users == null}");
            Console.WriteLine($"Command is null: {command == null}");
            Console.WriteLine($"Email is null/empty: {string.IsNullOrEmpty(command?.Email)}");
            Console.WriteLine($"Email value: '{command?.Email}'");

            if (await dbContext.Users.AnyAsync(x => x.Email == command.Email, cancellationToken))
            {
                return Result.Failure<Guid>(UserErrors.EmailNotUnique);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception details: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            throw;
        }
        // if (await dbContext.Users.AnyAsync(x => x.Email == command.Email, cancellationToken))
        // {
        //     return Result.Failure<Guid>(UserErrors.EmailNotUnique);
        // }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = command.Email,
            FirstName = command.FullName,
            LastName = command.ShortName,
            PasswordHash = "",
            IsActive = true,
            CreatedDate = _dateTimeProvider.UtcNow,
            ModifiedDate = _dateTimeProvider.UtcNow,
        };
        
        user.PasswordHash = passwordManager.HashPassword(command.Password);
        dbContext.Users.Add(user);

        var organization = new Organization
        {
            Id = Guid.NewGuid(),
            FullName = command.FullName,
            ShortName = command.ShortName,
            IsActive = true,
            CreatedDate = _dateTimeProvider.UtcNow,
            ModifiedDate = _dateTimeProvider.UtcNow
        };
        
        dbContext.Organizations.Add(organization);

        var organizationUser = new OrganizationUser
        {
            User = user,
            Organization = organization,
            Role = Role.OrganizationAdmin,
            CreatedDate = _dateTimeProvider.UtcNow,
            ModifiedDate = _dateTimeProvider.UtcNow,
            IsActive = true
        };
        
        dbContext.OrganizationUsers.Add(organizationUser);
        
        await dbContext.SaveChangesAsync(cancellationToken);

        return organization.Id;
    }
}