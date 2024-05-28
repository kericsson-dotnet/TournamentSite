using TournamentSite.Core.Entities;

namespace TournamentSite.Core.Repositories;

public interface IUoW
{
    IRepository<Tournament> TournamentRepository { get; }
    IRepository<Game> GameRepository { get; }

    Task CompleteAsync();
}
