using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.Domain.Projects;

namespace ArchiNote.Application.Projects.Create;

public sealed record CreateProjectCommand : ICommand<Guid>
{
    public string Name { get; set; }
    public ProjectStatus Status { get; set; }
}