using ArchiNote.Application.Abstractions.Authentication;
using ArchiNote.Domain.OrganizationUsers;
using Microsoft.AspNetCore.Http;

namespace ArchiNote.Infrastructure.Authentication;

internal sealed class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId =>
        _httpContextAccessor.HttpContext?
            .User
            .GetUserId() ?? 
        throw new ApplicationException("User context is unavailable");

    public Dictionary<Guid, Role> OrganizationRoles =>
        _httpContextAccessor.HttpContext?
            .User
            .GetOrganizationRoles();

    public List<Guid> CustomerOrganizations =>
        _httpContextAccessor.HttpContext?
            .User
            .GetCustomerOrganizations();

    public Guid? ActiveOrganizationId =>
        _httpContextAccessor.HttpContext?
            .User
            .GetActiveOrganizationId() ?? 
        throw new ApplicationException("User context is unavailable");
    
    public bool IsCustomer =>
        _httpContextAccessor.HttpContext?
            .User
            .IsCustomer() ?? false;
}