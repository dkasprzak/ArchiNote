using ArchiNote.Domain.Projects;

namespace ArchiNote.Application.Projects.Get;

public sealed record ProjectResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ProjectStatus Status { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset ModifiedDate { get; set; }
};