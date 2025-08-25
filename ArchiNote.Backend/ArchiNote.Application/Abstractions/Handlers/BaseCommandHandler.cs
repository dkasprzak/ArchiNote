using ArchiNote.Application.Abstractions.Data;
using ArchiNote.SharedKernel;

namespace ArchiNote.Application.Abstractions.Handlers;

public abstract class BaseCommandHandler
{
    protected readonly IApplicationDbContext _dbContext;
    protected readonly IDateTimeProvider _dateTimeProvider;

    protected BaseCommandHandler(IApplicationDbContext dbContext, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext;
        _dateTimeProvider = dateTimeProvider;
    }
}
