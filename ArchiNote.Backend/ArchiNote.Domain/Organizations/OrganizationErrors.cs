using ArchiNote.SharedKernel;

namespace ArchiNote.Domain.Organizations;

public static class OrganizationErrors
{
    public static Error NotFound(Guid organizationId) => Error.NotFound(
        "Organizations.NotFound",
        $"The organization with the Id = {organizationId} was not found");
}