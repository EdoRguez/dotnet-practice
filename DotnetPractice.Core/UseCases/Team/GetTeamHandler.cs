using DotnetPractice.Core.Common.Interfaces;

namespace DotnetPractice.Core.UseCases.Team;

public class GetTeamHandler
{
    private readonly ITeamRepository _repo;

    public GetTeamHandler(ITeamRepository repo)
    {
        _repo = repo;
    }

    public async Task<Entities.Team> Handle(Guid id)
    {
        var model = await _repo.Get(id);

        if(model is null)
            return null;

        return model;
    }
}