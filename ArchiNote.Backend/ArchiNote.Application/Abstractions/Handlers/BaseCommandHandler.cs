using ArchiNote.Application.Abstractions.Data;
using ArchiNote.SharedKernel;

namespace ArchiNote.Application.Abstractions.Handlers;

public abstract class BaseCommandHandler(IApplicationDbContext dbContext, IDateTimeProvider dateTimeProvider)
{
    protected readonly IApplicationDbContext _dbContext = dbContext;
    protected readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

    protected BaseCommandHandler(IApplicationDbContext dbContext) : this(dbContext, null)
    {
    }
    
 
}
