using Microsoft.EntityFrameworkCore;

namespace DotnetPractice.Infrastructure;

public class AppDbcontext : DbContext
{
    public AppDbContext(DbConextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Team> Teams { get; set; }
}