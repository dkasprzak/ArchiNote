using ArchiNote.Domain.Organizations;
using ArchiNote.Domain.Users;

namespace ArchiNote.Domain.OrganizationUsers;

public sealed class OrganizationUser
{
    public Guid OrganizationId { get; set; }
    public Organization Organization { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Role Role { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset ModifiedDate { get; set; }
    public bool IsActive { get; set; }
}