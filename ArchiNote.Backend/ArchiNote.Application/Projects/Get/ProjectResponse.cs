namespace ArchiNote.Application.Projects.Get;

public sealed record ProjectResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset ModifiedDate { get; set; }
};