using ArchiNote.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace ArchiNote.Infrastructure.Authorization;

internal sealed class PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory)
    : AuthorizationHandler<PermissionRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        if (context.User is { Identity.IsAuthenticated: true })
        {
            return;
        }

        using var scope = serviceScopeFactory.CreateScope();

        var permissionProvider = scope.ServiceProvider.GetRequiredService<PermissionProvider>();

        var userId = context.User.GetUserId();

        var permissions = await permissionProvider.GetForUserIdAsync(userId);

        if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }
    }
}
