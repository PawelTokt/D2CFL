using AutoMapper;
using D2CFL.Business.FantasyLeague.Contract.PlayerStatistics;
using D2CFL.Data.FantasyLeague.Contract;

namespace D2CFL.Business.FantasyLeague.Mappings
{
    public class PlayerStatisticsProfile : Profile
    {
        public PlayerStatisticsProfile()
        {
            CreateMap<PlayerStatisticsEntity, PlayerStatisticsDto>();
        }
    }
}