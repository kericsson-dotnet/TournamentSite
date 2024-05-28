run:
  @echo Running...
  dotnet run --project TournamentSite.Api    
watch:
  dotnet watch --project TournamentSite.Api    
dbu:
  dotnet ef database update --project TournamentSite.Data --startup-project TournamentSite.Api
dbd:
  dotnet ef database drop --project TournamentSite.Data --startup-project TournamentSite.Api
