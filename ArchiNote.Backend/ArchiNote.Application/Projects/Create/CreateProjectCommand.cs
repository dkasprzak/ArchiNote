using ArchiNote.Application.Abstractions.Messaging;

namespace ArchiNote.Application.Projects.Create;

public sealed record CreateProjectCommand : ICommand<Guid>
{
    public string Name { get; set; }
}