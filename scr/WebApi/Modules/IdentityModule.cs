using Application.Security;
using Asp.Versioning;
using Asp.Versioning.Builder;
using Carter;
using Domain.Models;

namespace WebApi.Modules;
public class IdentityModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet("Login")
        .HasApiVersion(new ApiVersion(1))
        .ReportApiVersions()
        .Build();

        app.MapPost("/api/v{version:apiVersion}/login", (ILogger<IdentityModule> log, JwtGenerator jwtService, LoginDto model) =>
        {
            if (jwtService.IsValidUser(model.Username, model.Password))
            {
                string token = jwtService.GenerateToken(model.Username!);
                log.LogInformation("JWT generado");

                return Results.Ok(new { Token = token });
            }
            else
            {
                return Results.Unauthorized();
            }
        })
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(1)
            .AllowAnonymous();
    }
}