using ArchiNote.Application.Abstractions.Messaging;

namespace ArchiNote.Application.Organizations.RegisterOrganization;

public sealed record RegisterOrganizationCommand : ICommand<Guid>
{
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public string Email { get; set; }
    public string ConfirmEmail { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password{ get; set; }
    public string ConfirmPassword{ get; set; }
}