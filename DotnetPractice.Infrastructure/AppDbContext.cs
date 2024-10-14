using DotnetPractice.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetPractice.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Team> Teams { get; set; }
}