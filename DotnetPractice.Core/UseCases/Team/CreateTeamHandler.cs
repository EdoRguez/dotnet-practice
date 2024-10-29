using DotnetPractice.Contracts.Team;
using DotnetPractice.Core.Repositories;

namespace DotnetPractice.Core.UseCases.Team;

public class CreateTeamHandler
{
    private readonly ITeamRepository _repo;

    public CreateTeamHandler(ITeamRepository repo)
    {
        _repo = repo;
    }

    public async Task<TeamResponse> Handle(CreateTeamRequest request)
    {
        var model = new Entities.Team(Guid.NewGuid(), request.Name);
        await _repo.Create(model);

        return new TeamResponse(
            model.Id,
            model.Name,
            null
        );
    }
}