using System.Reflection;
using ArchiNote.Application.Abstractions.Messaging;
using ArchiNote.Domain.Users;
using ArchiNote.Infrastructure.Database;
using Web.Api;
using Xunit.Abstractions;

namespace ArchitectureTests;

public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(User).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(ICommand).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(ApplicationDbContext).Assembly;
    protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
}