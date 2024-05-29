using AutoMapper;
using TournamentSite.Core.Dto;
using TournamentSite.Core.Entities;

namespace TournamentSite.Data.Data;

public class TournamentSiteMappings: Profile
{
    public TournamentSiteMappings()
    {
        CreateMap<Tournament, TournamentDto>();
        CreateMap<TournamentDto, Tournament>();
        CreateMap<Game, GameDto>();
        CreateMap<GameDto, Game>();
        // CreateMap<Tournament, TournamentDto>().PreserveReferences();
        // CreateMap<TournamentDto, Tournament>().PreserveReferences();
        // CreateMap<Game, GameDto>().PreserveReferences();
        // CreateMap<GameDto, Game>().PreserveReferences();
    }
}
