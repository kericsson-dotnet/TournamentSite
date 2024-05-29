using System.ComponentModel.DataAnnotations;

namespace TournamentSite.Core.Dto;

public class GameDto
{
    [Required]
    [StringLength(50)]
    public string Title { get; set; }
    public DateTime Time { get; set; }
}
