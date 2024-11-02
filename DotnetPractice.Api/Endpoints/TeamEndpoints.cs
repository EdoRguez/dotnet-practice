using DotnetPractice.Contracts.Team;
using DotnetPractice.Core.UseCases.Team;

namespace DotnetPractice.Api.Endpoints;

public static class TeamEndpoints
{
    public static RouteGroupBuilder MapTeamEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/teams");

        group.MapPost("/", async (CreateTeamRequest request, CreateTeamHandler handler) => {
            return await handler.Handle(request);
        });

        group.MapGet("/{id:guid}", async (Guid id, GetTeamHandler handler) => {
            var result = await handler.Handle(id);
            return result is null ? Results.NotFound() : Results.Ok(result);
        });

        return group;
    }
}