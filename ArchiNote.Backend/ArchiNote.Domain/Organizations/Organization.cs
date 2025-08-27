using ArchiNote.Domain.OrganizationUsers;
using ArchiNote.SharedKernel;

namespace ArchiNote.Domain.Organizations;

public sealed class Organization : Entity
{
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public bool IsActive { get; set; }
    public ICollection<OrganizationUser> OrganizationUsers { get; set; } = new List<OrganizationUser>();
}