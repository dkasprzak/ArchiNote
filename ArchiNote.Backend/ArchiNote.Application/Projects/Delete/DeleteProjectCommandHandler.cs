using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.SharedKernel;

namespace ArchiNote.Application.Projects.Delete;

public class DeleteProjectCommandHandler : ICommandHandler<DeleteProjectCommand>
{
    public Task<Result> Handle(DeleteProjectCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}