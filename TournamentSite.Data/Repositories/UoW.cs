using TournamentSite.Core.Entities;
using TournamentSite.Core.Repositories;
using TournamentSite.Data.Data;

namespace TournamentSite.Data.Repositories;

public class UoW(TournamentSiteContext context) : IUoW
{
    private readonly TournamentSiteContext _context = context;

    public ITournamentRepository TournamentRepository => new TournamentRepository(_context);

    public IRepository<Game> GameRepository => new GameRepository(_context);
    
    public async Task CompleteAsync()
    {
        _context.ChangeTracker.DetectChanges();
        Console.WriteLine(_context.ChangeTracker.DebugView.LongView);

        await _context.SaveChangesAsync();
    }
}
