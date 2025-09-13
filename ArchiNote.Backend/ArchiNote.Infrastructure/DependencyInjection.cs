using ArchiNote.Application.Abstractions.Authentication;
using ArchiNote.Application.Abstractions.Data;
using ArchiNote.Infrastructure.Authentication;
using ArchiNote.Infrastructure.Database;
using ArchiNote.Infrastructure.Time;
using ArchiNote.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArchiNote.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection
        AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddServices()
            .AddDatabase(configuration)
            .AddHealthChecks(configuration)
            .AddAuthenticationInternal(configuration);
    
    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<ApplicationDbContext>(
            options => options
                .UseNpgsql(connectionString, npgsqlOptions => 
                    npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Default))
            .UseSnakeCaseNamingConvention());
        
        services.AddScoped<IApplicationDbContext>(sp => sp.GetService<ApplicationDbContext>());
        
        return services;
    }
    
    private static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("Database")!);

        return services;
    }

    private static IServiceCollection AddAuthenticationInternal(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<IPasswordManager, PasswordManager>();
        
        return services;
    }
}