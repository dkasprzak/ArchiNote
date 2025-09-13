using ArchiNote.Domain.OrganizationUsers;

namespace ArchiNote.Application.Abstractions.Authentication;

public interface IUserContext
{
    Guid UserId { get; }
    Dictionary<Guid, Role> OrganizationRoles { get; }
    List<Guid> CustomerOrganizations { get; }
    Guid? ActiveOrganizationId { get; }
    bool IsCustomer { get; }
    bool IsSuperAdmin { get; }
}