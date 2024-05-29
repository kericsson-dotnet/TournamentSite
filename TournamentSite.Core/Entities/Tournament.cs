using System.ComponentModel.DataAnnotations;

namespace TournamentSite.Core.Entities;

public class Tournament
{
    public int TournamentId {get; set;}
     
    [Required]
    [StringLength(50)]
    public string Title {get; set;}

    public DateTime StartDate {get; set;}
    public ICollection<Game> Games {get; set;} = new List<Game>();
    
}
