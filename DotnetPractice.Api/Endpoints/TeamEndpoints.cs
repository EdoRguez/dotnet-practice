using DotnetPractice.Contracts.Team;
using DotnetPractice.Core.UseCases.Team;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace DotnetPractice.Api.Endpoints;

public static class TeamEndpoints
{
    public static RouteGroupBuilder MapTeamEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/teams");

        group.MapPost("/", async ([FromBody] CreateTeamRequest request, [FromServices] CreateTeamHandler handler, [FromServices] IMapper mapper) => {
            var createTeamResult = await handler.Handle(request);

            if(createTeamResult.IsFailed)
            {
                var firstError = createTeamResult.Errors[0];
                return Results.Problem(statusCode: (int) StatusCodes.Status409Conflict, detail: firstError.Message);
            }

            var result = mapper.Map<TeamResponse>(createTeamResult.Value);

            return Results.Ok(result);
        });

        group.MapGet("/{id:guid}", async ([FromRoute] Guid id, [FromServices] GetTeamHandler handler, [FromServices] IMapper mapper) => {
            var team = await handler.Handle(id);

            var result = mapper.Map<TeamResponse>(team);

            return result is null ? Results.NotFound() : Results.Ok(result);
        });

        return group;
    }
}