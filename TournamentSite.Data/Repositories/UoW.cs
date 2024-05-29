using TournamentSite.Core.Entities;
using TournamentSite.Core.Repositories;
using TournamentSite.Data.Data;

namespace TournamentSite.Data.Repositories;

public class UoW(TournamentSiteContext context) : IUoW
{
    private readonly TournamentSiteContext _context = context;

    public IRepository<Tournament> TournamentRepository => new TournamentRepository(_context);

    public IRepository<Game> GameRepository => new GameRepository(_context);

    public Task CompleteAsync()
    {
        _context.ChangeTracker.DetectChanges();
        Console.WriteLine(_context.ChangeTracker.DebugView.LongView);
        _context.SaveChangesAsync();
        return Task.CompletedTask;
    }
}
