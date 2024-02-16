using Application;
using Application.Security;
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
