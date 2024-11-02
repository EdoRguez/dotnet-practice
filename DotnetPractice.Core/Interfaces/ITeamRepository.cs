using DotnetPractice.Core.Entities;

namespace DotnetPractice.Core.Interfaces;

public interface ITeamRepository
{
    Task Create(Team model);
    Task<IEnumerable<Team>> GetAll(int limit, int offset, bool trackChanges = false);
    Task<Team?> Get(Guid id, bool trackChanges = false);
    Task Delete(Team model);
}