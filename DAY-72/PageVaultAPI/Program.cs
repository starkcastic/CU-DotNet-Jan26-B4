using Serilog;
using Microsoft.EntityFrameworkCore;
using PageVaultAPI.Data;
using PageVaultAPI.Middleware;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting PageVault API...");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, configuration) =>
        configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services));

    builder.Services.AddDbContext<PageVaultDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("PageVaultDB")));

    builder.Services.AddControllers()
        .AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler =
                System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();
    app.MapControllers();
    Log.Information("PageVault API running at: {Urls}", 
    string.Join(", ", app.Urls));

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "PageVault API terminated unexpectedly.");
}
finally
{
    Log.CloseAndFlush();
}