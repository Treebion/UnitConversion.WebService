using FluentValidation;
using MediatR;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using UnitConversion.WebService.Examples;
using UnitConversion.WebService.Infrastructure;
using UnitConversion.WebService.Middleware;

namespace UnitConversion.WebService;

/// <summary>
/// The main program class for the Unit Conversion Web Service.
/// </summary>
public class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder.Services);
        var app = builder.Build();
        ConfigureMiddleware(app);

        app.Run();
    }

    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Unit Conversion API", Version = "v1" });
            var mainXmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var mainXmlPath = Path.Combine(AppContext.BaseDirectory, mainXmlFilename);
            if (File.Exists(mainXmlPath))
            {
                options.IncludeXmlComments(mainXmlPath);
            }

            var nugetPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".nuget", "packages", "treebion.unitconversion");

            if (Directory.Exists(nugetPath))
            {
                var versions = Directory.GetDirectories(nugetPath);
                var latestVersion = versions.OrderByDescending(v => v).FirstOrDefault();
                if (latestVersion != null)
                {
                    var xmlPath = Path.Combine(latestVersion, "lib", "net8.0", "UnitConversion.xml");
                    if (File.Exists(xmlPath))
                    {
                        options.IncludeXmlComments(xmlPath);
                        options.SchemaFilter<XmlEnumDescriptionsSchemaFilter>(xmlPath);
                    }
                }
            }
            options.ExampleFilters();

        });
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddRateLimiter(options =>
        {
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
                RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                    factory: _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 10,
                        Window = TimeSpan.FromSeconds(30),
                        QueueLimit = 0
                    }
                ));

            options.RejectionStatusCode = 429;
        });
    }

    /// <summary>
    /// Configures the middleware for the application.
    /// </summary>
    /// <param name="app">The web application to configure.</param>
    private static void ConfigureMiddleware(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRateLimiter();
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}
