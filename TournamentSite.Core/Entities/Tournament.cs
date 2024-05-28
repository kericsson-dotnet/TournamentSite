namespace TournamentSite.Core.Entities;

public class Tournament
{
    public int TournamentId {get; set;}
    public string Title {get; set;}
    public DateTime StartDate {get; set;}
    public ICollection<Game> Games {get; set;} = new List<Game>();
    
}
