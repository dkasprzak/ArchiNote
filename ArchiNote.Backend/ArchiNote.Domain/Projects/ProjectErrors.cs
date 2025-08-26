using ArchiNote.SharedKernel;

namespace ArchiNote.Domain.Projects;

public static class ProjectErrors
{
    public static Error NotFound(Guid projectId) => Error.NotFound(
            "Projects.NotFound",
            $"The project with the Id = '{projectId}' was not found");
}