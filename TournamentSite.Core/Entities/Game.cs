namespace TournamentSite.Core.Entities;

public class Game
{
    public int GameId { get; set; }
    public string Title { get; set; }
    public DateTime Time { get; set; }
    public int TournamentId { get; set; }

    public Game()
    {
    }
}

