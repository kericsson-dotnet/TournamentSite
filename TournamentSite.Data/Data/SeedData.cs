using TournamentSite.Core.Entities;

namespace TournamentSite.Data.Data;


public class SeedData
{
    public static async Task InitAsync(TournamentSiteContext context)
    {
        if (!context.Tournament.Any())
        {
            var seedTournament = new Tournament { Title = "Tournament One", StartDate = DateTime.Now };
            await context.Tournament.AddAsync(seedTournament);
            await context.SaveChangesAsync();
        }
        

        if (!context.Game.Any())
        {
            var seedGame = new Game { Title = "Game One", Time = DateTime.Now, TournamentId = 1 };
            await context.Game.AddAsync(seedGame);
            await context.SaveChangesAsync();
        }
    }
}
