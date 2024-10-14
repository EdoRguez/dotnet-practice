using DotnetPractice.Contracts.Player;

namespace DotnetPractice.Contracts.Team;

public record TeamResponse(
    Guid Id,
    string Name,
    List<PlayerResponse> Players
);