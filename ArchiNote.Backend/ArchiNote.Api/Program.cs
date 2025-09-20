using System.Reflection;
using ArchiNote.Api;
using ArchiNote.Api.Extensions;
using ArchiNote.Application;
using ArchiNote.Infrastructure;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.Services.AddCors();

var app = builder.Build();

app.UseCorsExtension(builder.Configuration);

var apiGroup = app.MapGroup("/api");
app.MapEndpoints(apiGroup);

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUi();
    
    app.ApplyMigrations();
}

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseRequestContextLogging();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseAuthorization();

app.UseAuthentication();
 
await app.RunAsync();

// REMARK: Required for functional and integration tests to work.
namespace Web.Api
{
    public partial class Program;
}
