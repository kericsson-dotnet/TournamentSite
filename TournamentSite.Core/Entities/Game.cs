using System.ComponentModel.DataAnnotations;

namespace TournamentSite.Core.Entities;

public class Game
{
    public int GameId { get; set; }

    [MaxLength(50)]
    public required string Title { get; set; }

    public DateTime Time { get; set; }
    public int TournamentId { get; set; }
}
