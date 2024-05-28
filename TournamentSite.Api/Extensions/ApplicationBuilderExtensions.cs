using TournamentSite.Data.Data;

namespace TournamentSite.Api.Extensions;

public static class ApplicationBuilderExtensions
{
  public static async Task SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<TournamentSiteContext>();

                // await context.Database.EnsureDeletedAsync();
                // await context.Database.EnsureCreatedAsync();

                try
                {
                    await SeedData.InitAsync(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }

            }
        }
}
