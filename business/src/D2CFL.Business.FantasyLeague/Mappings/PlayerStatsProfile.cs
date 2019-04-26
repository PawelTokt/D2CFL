using AutoMapper;
using D2CFL.Business.FantasyLeague.Contract.PlayerStats;
using D2CFL.Data.FantasyLeague.Contract;

namespace D2CFL.Business.FantasyLeague.Mappings
{
    public class PlayerStatsProfile : Profile
    {
        public PlayerStatsProfile()
        {
            CreateMap<PlayerStatsEntity, PlayerStatsDto>()
                .ForMember(x => x.MathcName, opts => opts.MapFrom(src => src.Match.Name))
                .ForMember(x => x.PlayerNickName, opts => opts.MapFrom(src => src.Player.Nickname));

            CreateMap<IPlayerStatsDto, PlayerStatsEntity>();
        }
    }
}
