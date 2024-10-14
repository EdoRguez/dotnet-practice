using DotnetPractice.Core.Entities;
using DotnetPractice.Core.Repositories;

namespace DotnetPractice.Infrastructure.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly AppDbcontext _context;

    public TeamRepository(AppDbcontext context)
    {
        _context = context;
    }

    public async Task<Team> Create(Team model)
    {
        await _context.Teams.Add(model);
    }

    public async Task Delete(Guid id)
    {
        var team = await _context.Teams.(x => x.Id == id);
        await _context.Teams.Delete(team);
    }

    public async Task<Team> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Team>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task Update(Guid id, Team model)
    {
        throw new NotImplementedException();
    }
}