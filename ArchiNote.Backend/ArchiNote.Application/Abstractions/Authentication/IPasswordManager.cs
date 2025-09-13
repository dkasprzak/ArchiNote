namespace ArchiNote.Application.Abstractions.Authentication;

public interface IPasswordManager
{
    string HashPassword(string password);
    bool VerifyPassword(string hash, string password);
}