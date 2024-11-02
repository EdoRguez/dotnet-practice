using DotnetPractice.Contracts.Team;
using DotnetPractice.Core.Interfaces;

namespace DotnetPractice.Core.UseCases.Team;

public class CreateTeamHandler
{
    private readonly ITeamRepository _repo;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTeamHandler(ITeamRepository repo, IUnitOfWork unitOfWork)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
    }

    public async Task<TeamResponse> Handle(CreateTeamRequest request)
    {
        var model = new Entities.Team(Guid.NewGuid(), request.Name);
        await _repo.Create(model);
        await _unitOfWork.SaveChangesAsync();

        return new TeamResponse(
            model.Id,
            model.Name,
            null
        );
    }
}