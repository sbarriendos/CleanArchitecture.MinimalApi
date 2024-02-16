using Application.Security;
using Carter;
using Domain.Models;

namespace WebApi.Modules;
public class IdentityModule : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/login", (ILogger<IdentityModule> log, JwtGenerator jwtService, LoginModel model) =>
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
        .AllowAnonymous();
    }
}