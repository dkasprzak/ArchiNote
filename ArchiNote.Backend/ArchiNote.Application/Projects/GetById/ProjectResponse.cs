namespace ArchiNote.Application.Projects.GetById;

public sealed record ProjectResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
};