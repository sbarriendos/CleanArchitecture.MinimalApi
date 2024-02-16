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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Map Endpoints
app.MapCarter();

app.Run();