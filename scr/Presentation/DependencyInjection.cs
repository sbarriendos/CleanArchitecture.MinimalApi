
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Validators;

namespace Presentation;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<PostValidator>();

        return services;
    }
}
