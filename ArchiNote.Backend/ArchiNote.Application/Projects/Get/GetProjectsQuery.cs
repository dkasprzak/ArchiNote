using ArchiNote.Application.Abstractions.Messaging;

namespace ArchiNote.Application.Projects.Get;

public sealed record GetProjectsQuery : IQuery<List<ProjectResponse>>;