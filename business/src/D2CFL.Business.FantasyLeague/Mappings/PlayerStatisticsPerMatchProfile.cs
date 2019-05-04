using AutoMapper;
using D2CFL.Business.FantasyLeague.Contract.PlayerStatisticsPerMatch;
using D2CFL.Data.FantasyLeague.Contract;

namespace D2CFL.Business.FantasyLeague.Mappings
{
    public class PlayerStatisticsPerMatchProfile : Profile
    {
        public PlayerStatisticsPerMatchProfile()
        {
            CreateMap<PlayerStatisticsPerMatchEntity, PlayerStatisticsPerMatchDto>()
                .ForMember(x => x.PlayerNickname, opts => opts.MapFrom(src => src.Player.Nickname));

            CreateMap<PlayerStatisticsPerMatchEntity, IPlayerStatisticsPerMatchDto>();

            CreateMap<IPlayerStatisticsPerMatchDto, PlayerStatisticsPerMatchEntity>()
                .ForMember(x => x.PlayerNickname, opts => opts.Ignore());
        }
    }
}
