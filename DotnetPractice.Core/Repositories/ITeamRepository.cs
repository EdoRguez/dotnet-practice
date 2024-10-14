using DotnetPractice.Core.Entities;

namespace DotnetPractice.Core.Repositories;

public interface ITeamRepository
{
    Task<Team> Create(Team model);
    Task<IEnumerable<Team>> GetAll();
    Task<Team> Get(Guid id);
    Task Update(Guid id, Team model);
    Task Delete(Guid id);
}