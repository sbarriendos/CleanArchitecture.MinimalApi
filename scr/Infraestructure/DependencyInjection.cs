using Application.Abstractions;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfraestrucutre(this IServiceCollection services)
    {
        services.AddDbContext<SocialDbContext>(options => options.UseInMemoryDatabase("SocialDB"));

        services.AddScoped<IPostRepository, PostRepository>();

        return services;
    }
}
