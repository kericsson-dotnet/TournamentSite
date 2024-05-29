// using TournamentSite.Core.Entities;


using System.ComponentModel.DataAnnotations;

namespace TournamentSite.Core.Dto;

public class TournamentDto
{
    [Required]
    [StringLength(50)]
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate => StartDate.AddMonths(3);
    public ICollection<GameDto> Games { get; set; } = new List<GameDto>();
}

