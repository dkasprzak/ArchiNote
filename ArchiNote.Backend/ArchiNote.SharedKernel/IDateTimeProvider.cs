namespace ArchiNote.SharedKernel;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}