using Application;
using Application.Security;
using Asp.Versioning;
using Carter;
using Infraestructure;
using Microsoft.Extensions.Options;
using Presentation;
using Serilog;
namespace WebApi.Extensions;

public static class WebApiExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, config) =>
            config.ReadFrom.Configuration(context.Configuration)
        );

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new(5, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));

        }).AddApiExplorer(options =>
        {
            // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        builder.Services.AddSwagger();

        builder.Services.AddCarter();

        builder.Services
            .AddApplication(builder.Configuration)
            .AddInfraestrucutre()
            .AddPresentation();

        IOptions<JwtSettings> jwtSettings = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtSettings>>();
        builder.AddAuthentication(jwtSettings);
        builder.AddAuthorizationBuilder();
    }
}