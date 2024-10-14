using DotnetPractice.Core.Entities;
using DotnetPractice.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotnetPractice.Infrastructure.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly AppDbContext _context;

    public TeamRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(Team model)
    {
        _context.Teams.Add(model);
        await Task.CompletedTask;
    }

    public async Task Delete(Team model)
    {
       _context.Teams.Remove(model);
       await Task.CompletedTask;
    }

    public async Task<Team?> Get(Guid id, bool trackChanges = false)
    {
        if(trackChanges)
            return await _context.Teams.SingleOrDefaultAsync(x => x.Id == id);

        return await _context.Teams.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Team>> GetAll(int limit, int offset, bool trackChanges = false)
    {
        if(trackChanges)
            return await _context.Teams.Take(limit).Skip(offset).ToListAsync();

        return await _context.Teams.AsNoTracking().Take(limit).Skip(offset).ToListAsync();
    }
}