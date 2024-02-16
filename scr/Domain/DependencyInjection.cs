using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Domain;
public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        Assembly assembly = typeof(DependencyInjection).Assembly;


        return services;
    }
}
