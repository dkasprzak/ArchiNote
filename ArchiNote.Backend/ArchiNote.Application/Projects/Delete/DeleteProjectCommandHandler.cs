using ArchiNote.Application.Abstractions.Data;
using ArchiNote.Application.Abstractions.Handlers;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.SharedKernel;

namespace ArchiNote.Application.Projects.Delete;

internal sealed class DeleteProjectCommandHandler : BaseCommandHandler, ICommandHandler<DeleteProjectCommand>
{
    public DeleteProjectCommandHandler(IApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task<Result> Handle(DeleteProjectCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}