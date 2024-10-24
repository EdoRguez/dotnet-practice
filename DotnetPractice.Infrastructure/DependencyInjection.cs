using DotnetPractice.Core.Repositories;
using DotnetPractice.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetPractice.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddContext()
                .AddPersistence();

        return services;
    }

    public static IServiceCollection AddContext(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => {
            options.UseNpgsql("Server=127.0.0.1;Port=5488;Database=dotnet-practice-db;User Id=postgres;Password=postgres;");
        });

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<ITeamRepository, TeamRepository>();

        return services;
    }
}