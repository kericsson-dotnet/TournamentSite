using Microsoft.EntityFrameworkCore;
using TournamentSite.Core.Entities;
using TournamentSite.Core.Repositories;
using TournamentSite.Data.Data;

namespace TournamentSite.Data.Repositories;

public class GameRepository(TournamentSiteContext context) : IRepository<Game>
{
    private readonly TournamentSiteContext _context = context;

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await _context.Game.ToListAsync();
    }

    public async Task<Game> GetAsync(int id)
    {
        var game = await _context.Game.FirstOrDefaultAsync(g => g.GameId == id);
        if (game == null)
        {
            throw new InvalidOperationException($"GameId: {id} not found");
        }
        return game;
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
