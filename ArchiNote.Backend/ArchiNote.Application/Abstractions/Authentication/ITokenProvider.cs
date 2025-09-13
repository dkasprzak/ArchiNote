using ArchiNote.Domain.Users;

namespace ArchiNote.Application.Abstractions.Authentication;

public interface ITokenProvider
{
    string Create(User user, Guid? activeOrganizationId = null);
}