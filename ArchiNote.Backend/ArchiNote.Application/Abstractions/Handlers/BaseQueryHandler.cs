using ArchiNote.Application.Abstractions.Data;
using ArchiNote.SharedKernel;

namespace ArchiNote.Application.Abstractions.Handlers;

public abstract class BaseQueryHandler
{
    protected readonly IApplicationDbContext _dbContext;

    protected BaseQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}