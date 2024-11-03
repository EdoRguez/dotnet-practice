using DotnetPractice.Contracts.Team;
using FluentValidation;

namespace DotnetPractice.Core.Common.Validators;

public class CreateTeamValidator : AbstractValidator<CreateTeamRequest>
{
    public CreateTeamValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
                            .MaximumLength(10)
                            .WithMessage("Hey! there is an error here bro");
    }
}