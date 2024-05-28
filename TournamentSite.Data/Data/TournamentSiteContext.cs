using Microsoft.EntityFrameworkCore;
using TournamentSite.Core.Entities;

namespace TournamentSite.Data.Data;

public class TournamentSiteContext : DbContext
{
    public TournamentSiteContext(DbContextOptions<TournamentSiteContext> options)
        : base(options)
    {
    }

    public DbSet<Tournament> Tournament { get; set; } = default!;
    public DbSet<Game> Game { get; set; } = default!;
}
