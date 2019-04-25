using AutoMapper;
using D2CFL.Business.FantasyLeague.Contract.Tournament;
using D2CFL.Data.FantasyLeague.Contract;

namespace D2CFL.Business.FantasyLeague.Mappings
{
    public class TournamentProfile : Profile
    {
        public TournamentProfile()
        {
            CreateMap<TournamentEntity, TournamentDto>();
            CreateMap<ITournamentDto, TournamentEntity>();
        }
    }
}
