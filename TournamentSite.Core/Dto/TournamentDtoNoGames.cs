using System.ComponentModel.DataAnnotations;

namespace TournamentSite.Core.Dto;

public class TournamentDtoNoGames
{
    [StringLength(50)]
    public required string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate => StartDate.AddMonths(3);
}

