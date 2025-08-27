using ArchiNote.Domain.OrganizationUsers;
using ArchiNote.SharedKernel;

namespace ArchiNote.Domain.Users;

public sealed class User : Entity
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; }
    public ICollection<OrganizationUser> OrganizationUsers { get; set; } = new List<OrganizationUser>();
}