using ArchiNote.Application.Abstractions.Messaging;

namespace ArchiNote.Application.Projects.GetById;

public record GetProjectByIdQuery(Guid ProjectId) : IQuery<ProjectResponse>;