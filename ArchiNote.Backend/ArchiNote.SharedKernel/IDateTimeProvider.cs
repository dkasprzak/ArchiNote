namespace ArchiNote.SharedKernel;

public interface IDateTimeProvider
{
    DateTimeOffset UtcNow { get; }
}