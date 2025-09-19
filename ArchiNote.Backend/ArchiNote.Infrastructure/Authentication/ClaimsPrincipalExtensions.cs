using System.Security.Claims;
using ArchiNote.Domain.OrganizationUsers;
using Microsoft.IdentityModel.JsonWebTokens;

namespace ArchiNote.Infrastructure.Authentication;

internal static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        var userId = principal?.FindFirstValue(JwtRegisteredClaimNames.Sub);
        
        return Guid.TryParse(userId, out Guid parsedUserId) ? parsedUserId : 
                throw new ApplicationException("User Id is unavailable");
    }

    public static Dictionary<Guid, Role> GetOrganizationRoles(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            return new Dictionary<Guid, Role>();
        }

        return principal.FindAll("org_role")
            .Select(c => c.Value.Split(':'))
            .Where(parts => parts.Length == 2)
            .ToDictionary(
                parts => Guid.Parse(parts[0]),
                parts => Enum.Parse<Role>(parts[1])
            );
    }

    public static List<Guid> GetCustomerOrganizations(this ClaimsPrincipal principal)
    {
        return principal?.GetOrganizationRoles()
            .Where(kvp => kvp.Value == Role.Admin)
            .Select(kvp => kvp.Key)
            .ToList() ?? new List<Guid>();
    }

    public static Guid? GetActiveOrganizationId(this ClaimsPrincipal principal)
    {
        var activeOrg = principal?.FindFirstValue("active_org");
        return Guid.TryParse(activeOrg, out Guid parsedOrgId) ? parsedOrgId : null;
    }

    public static bool IsCustomer(this ClaimsPrincipal principal)
    {
        return principal?.GetCustomerOrganizations().Any() ?? false;
    }
}