using DotnetPractice.Contracts.Team;
using DotnetPractice.Core.Repositories;

namespace DotnetPractice.Core.UseCases.Team;

public class GetTeamHandler
{
    private readonly ITeamRepository _repo;

    public GetTeamHandler(ITeamRepository repo)
    {
        _repo = repo;
    }

    public async Task<TeamResponse> Handle(Guid id)
    {
        var model = await _repo.Get(id);
        return new TeamResponse(
            model.Id,
            model.Name,
            null
        );
    }
}