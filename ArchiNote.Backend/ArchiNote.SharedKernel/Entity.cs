namespace ArchiNote.SharedKernel;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}