// using TournamentSite.Core.Entities;


namespace TournamentSite.Core.Dto;

public class TournamentDto
{

    public string Title { get; set; }
    public DateTime StartDate {get; set;}
    public DateTime EndDate => StartDate.AddMonths(3);
    // public ICollection<GameDto> Games {get; set;} = new List<GameDto>();
}

