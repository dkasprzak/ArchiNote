namespace ArchiNote.Api.Extensions;

public static class CorsExtension
{
    public static IApplicationBuilder UseCorsExtension(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseCors(builder => builder
            .WithOrigins(configuration.GetValue<string>("WebAppBaseUrl") ?? "")
            .WithOrigins(configuration.GetSection("AdditionalCorsOrigins").Get<string[]>() ?? new string[0])
            .WithOrigins((Environment.GetEnvironmentVariable("AdditionalCorsOrigins") ?? "").Split(',').Where(h => !string.IsNullOrEmpty(h)).Select(h => h.Trim()).ToArray())
            .AllowAnyHeader()
            .AllowCredentials()
            .AllowAnyMethod());
        
        return app;
    }
}