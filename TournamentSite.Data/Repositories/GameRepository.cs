using Microsoft.EntityFrameworkCore;
using TournamentSite.Core.Entities;
using TournamentSite.Core.Repositories;
using TournamentSite.Data.Data;

namespace TournamentSite.Data.Repositories;

public class GameRepository : IRepository<Game>
{
    private readonly TournamentSiteContext _context;

    public GameRepository(TournamentSiteContext context)
    {
        _context = context;
    }

   public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await _context.Game.ToListAsync();
    }

    public async Task<Game> GetAsync(int id)
    {
        return await _context.Game.FindAsync(id);
    }

    public async Task<bool> AnyAsync(int id)
    {
        return await _context.Game.AnyAsync(e => e.GameId == id);
    }

     public void Add(Game entity)
    {
         _context.Game.AddAsync(entity);
    }

    public void Update(Game entity)
    {
        _context.Game.Update(entity);
    }

    public void Remove(Game entity)
    {
        _context.Game.Remove(entity);
    }
 
}