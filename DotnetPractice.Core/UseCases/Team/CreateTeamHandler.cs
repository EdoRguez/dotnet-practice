using DotnetPractice.Contracts.Team;
using DotnetPractice.Core.Common.Interfaces;
using DotnetPractice.Core.Common.Validators;
using FluentResults;

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

    public async Task<Result<Entities.Team>> Handle(CreateTeamRequest request)
    {
        CreateTeamValidator validator = new CreateTeamValidator();

        var validationResult = await validator.ValidateAsync(request);

        if(!validationResult.IsValid)
        {
            var errors = validationResult.Errors.ConvertAll(x => new Error(x.ErrorMessage));
            return Result.Fail(errors);
        }

        var model = new Entities.Team(Guid.NewGuid(), request.Name);
        await _repo.Create(model);
        await _unitOfWork.SaveChangesAsync();

       return model;
    }
}