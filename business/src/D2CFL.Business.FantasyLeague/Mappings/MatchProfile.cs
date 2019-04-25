using AutoMapper;
using D2CFL.Business.FantasyLeague.Contract.Match;
using D2CFL.Data.FantasyLeague.Contract;

namespace D2CFL.Business.FantasyLeague.Mappings
{
    public class MatchProfile : Profile
    {
        public MatchProfile() {
            CreateMap<MatchEntity, MatchDto>()
                .ForMember(x => x.TournamentName, opts => opts.MapFrom(src => src.Tournament.Name));
            CreateMap<IMatchDto, MatchEntity>();
        }
    }
}