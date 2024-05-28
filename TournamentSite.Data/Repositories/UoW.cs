using TournamentSite.Core.Entities;
using TournamentSite.Core.Repositories;
using TournamentSite.Data.Data;

namespace TournamentSite.Data.Repositories;

public class UoW : IUoW
{
    private readonly TournamentSiteContext _context;
    public UoW(TournamentSiteContext context)
    {
        _context = context;
    }

    public IRepository<Tournament> TournamentRepository => new TournamentRepository(_context);

    public IRepository<Game> GameRepository => new GameRepository(_context);

    public Task CompleteAsync()
    {
        _context.SaveChangesAsync();
        return Task.CompletedTask;
    }
}
