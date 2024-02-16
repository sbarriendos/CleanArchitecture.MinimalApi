using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Validators;
public class ValidationFilter<T> : IEndpointFilter where T : class
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        IValidator<T> validator = context.HttpContext.RequestServices.GetRequiredService<IValidator<T>>();

        if (validator is null)
            return new BadRequestObjectResult("Invalid request. Some elements are null");


        T? entity = context.Arguments
            .OfType<T>()
            .FirstOrDefault(arg => arg is not null);

        if (entity is null)
            return Results.Problem("Could not find type to validate");


        ValidationResult validation = await validator.ValidateAsync(entity);

        if (validation.IsValid)
            return await next(context);
        else
            return Results.ValidationProblem(validation.ToDictionary());
    }
}
