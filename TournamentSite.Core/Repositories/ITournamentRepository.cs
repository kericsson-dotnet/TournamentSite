using TournamentSite.Core.Entities;

namespace TournamentSite.Core.Repositories;

public interface ITournamentRepository
{
    Task<IEnumerable<Tournament>> GetAllAsync(bool includeGames);
    Task<Tournament> GetAsync(int id);
    Task<bool> AnyAsync(int id);
    void Add(Tournament entity);
    void Update(Tournament entity);
    void Remove(Tournament entity);
}
