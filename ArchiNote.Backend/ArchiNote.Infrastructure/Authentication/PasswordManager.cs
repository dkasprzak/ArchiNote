using ArchiNote.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Identity;

namespace ArchiNote.Infrastructure.Authentication;

internal sealed class PasswordManager(IPasswordHasher<PasswordManager.DummyUser> passwordHasher) : IPasswordManager
{
    public string HashPassword(string password)
    {
        return passwordHasher.HashPassword(new DummyUser(), password);
    }

    public bool VerifyPassword(string hash, string password)
    {
        var verificationResult = passwordHasher.VerifyHashedPassword(new DummyUser(), hash, password);
        return verificationResult is PasswordVerificationResult.Success or PasswordVerificationResult.SuccessRehashNeeded;
    }
    
    public sealed class DummyUser;
}