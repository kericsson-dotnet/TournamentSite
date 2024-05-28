using Microsoft.EntityFrameworkCore;
using TournamentSite.Core.Entities;
using TournamentSite.Core.Repositories;
using TournamentSite.Data.Data;

namespace TournamentSite.Data.Repositories;

public class TournamentRepository(TournamentSiteContext context) : IRepository<Tournament>
{
    private readonly TournamentSiteContext _context = context;

    public async Task<IEnumerable<Tournament>> GetAllAsync()
    {
        return await _context.Tournament.Include(t => t.Games).ToListAsync();
    }

    public async Task<Tournament> GetAsync(int id)
    {
        return await _context.Tournament.Include(t => t.Games).FirstOrDefaultAsync(t => t.TournamentId == id);
    }

    public async Task<bool> AnyAsync(int id)
    {
        return await _context.Tournament.AnyAsync(t => t.TournamentId == id); 
    }

     public void Add(Tournament entity)
    {
        _context.Tournament.Add(entity);
    }

    public void Update(Tournament entity)
    {
        _context.Tournament.Update(entity);
    }

    public void Remove(Tournament entity)
    {
        _context.Tournament.Remove(entity);
    }
 
}
