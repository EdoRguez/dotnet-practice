using DotnetPractice.Core.Common.Interfaces;
using DotnetPractice.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetPractice.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddContext(config)
                .AddPersistence();

        return services;
    }

    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options => {
            options.UseNpgsql(config["DbConnectionString"]);
        });

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITeamRepository, TeamRepository>();

        return services;
    }
}