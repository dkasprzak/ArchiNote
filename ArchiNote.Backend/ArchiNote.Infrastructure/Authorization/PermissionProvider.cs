using ArchiNote.Application.Abstractions.Authentication;
using ArchiNote.Domain.OrganizationUsers;

namespace ArchiNote.Infrastructure.Authorization;

internal sealed class PermissionProvider
{
    private readonly IUserContext _userContext;

    public PermissionProvider(IUserContext userContext)
    {
        _userContext = userContext;
    }

    public Task<HashSet<string>> GetForUserIdAsync(Guid userId)
    {
        var permissions = new HashSet<string>();

        permissions.Add("projects:read");

        if (_userContext.ActiveOrganizationId.HasValue)
        {
            var orgRoles = _userContext.OrganizationRoles;
            var activeOrgRole = orgRoles[_userContext.ActiveOrganizationId.Value];

            var rolePermissions = activeOrgRole switch
            {
                Role.Admin => new[]
                {
                    "projects:create", "projects:update", "projects:delete",
                    "users:read", "users:create", "users:update", "users:delete",
                    "organizations:delete",
                },
                
                Role.ProjectManager => new[]
                {
                    "projects:create", "projects:update",
                    "users:read", "users:create", "users:update"
                },
                
                Role.Employee => new[]
                {
                    "projects:create", "projects:update"
                },
                
                _ => Array.Empty<string>()
            };

            foreach (var permission in rolePermissions)
            {
                permissions.Add(permission);
            }
        }
        
        return Task.FromResult(permissions);
    }
    
    private static HashSet<string> GetAllPermissions()
    {
        return new HashSet<string>
        {
            // Projects
            "projects:read", "projects:create", "projects:update", "projects:delete",
            
            // Users  
            "users:read", "users:create", "users:update", "users:delete",
            
            // Organizations
            "organizations:read", "organizations:create", "organizations:update", "organizations:delete",
            
            // System Admin permissions
            "system:logs:read",
            "system:settings:update",
            "system:backup:create",
            
            // Super Admin exclusive
            "superadmin:users:promote",
            "superadmin:organizations:manage",
            "superadmin:system:access"
        };
    }
}