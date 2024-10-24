using DotnetPractice.Core.UseCases.Team;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetPractice.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<CreateTeamHandler>()
                .AddScoped<GetTeamHandler>();

        return services;
    }
}