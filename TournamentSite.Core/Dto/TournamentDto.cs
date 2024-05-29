using System.ComponentModel.DataAnnotations;

namespace TournamentSite.Core.Dto;

public class TournamentDto
{
    [StringLength(50)]
    public required string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate => StartDate.AddMonths(3);
    public ICollection<GameDto> Games { get; set; } = new List<GameDto>();
}

