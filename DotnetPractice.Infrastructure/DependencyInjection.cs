using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetPractice.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddContext();

        return services;
    }

    public static IServiceCollection AddContext(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => {
            options.UseNpgsql("");
        });

        return services;
    }
}