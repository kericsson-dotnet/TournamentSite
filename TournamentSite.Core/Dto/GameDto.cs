using System.ComponentModel.DataAnnotations;

namespace TournamentSite.Core.Dto;

public class GameDto
{
    [StringLength(50)]
    public required string Title { get; set; }
    public DateTime Time { get; set; }
    public int TournamentId { get; set; }
}
