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
        var data = await _repo.Create(model);

        return new TeamResponse(
            data.Id,
            data.Name,
            null
        );
    }
}