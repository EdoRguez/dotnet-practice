using DotnetPractice.Contracts.Team;
using DotnetPractice.Core.Entities;
using Mapster;

namespace DotnetPractice.Api.Common.Mapping;

public class TeamMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Team, TeamResponse>();
    }
}