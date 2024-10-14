namespace DotnetPractice.Contracts.Team;

public record UpdateTeamRequest(
    Guid Id,
    string Name
);