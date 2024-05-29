using TournamentSite.Core.Entities;

namespace TournamentSite.Core.Repositories;

public interface IUoW
{
    ITournamentRepository TournamentRepository { get; }
    IRepository<Game> GameRepository { get; }

    Task CompleteAsync();
}
