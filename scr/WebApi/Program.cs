using Asp.Versioning.ApiExplorer;
using Carter;
using Presentation.Middlewares;
using Serilog;
using WebApi.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

WebApplication app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp =>
exceptionHandlerApp.Run(async context =>
    await Results.Problem().ExecuteAsync(context)));

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

// Map Endpoints
app.MapCarter();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        IReadOnlyList<ApiVersionDescription> descriptions = app.DescribeApiVersions();

        foreach (ApiVersionDescription description in descriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                $"Minimal Api - {description.GroupName.ToUpper()}");
        }
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.Run();