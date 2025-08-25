using ArchiNote.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ArchiNote.Api.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

        using ApplicationDbContext dbContext = 
            serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    
        dbContext.Database.Migrate();
    }
}