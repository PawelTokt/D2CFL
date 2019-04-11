using AutoMapper;
using D2CFL.Business.FantasyLeague.Contract.Position;
using D2CFL.Data.FantasyLeague.Contract;

namespace D2CFL.Business.FantasyLeague.Mappings
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<PositionEntity, PositionDto>();
            CreateMap<IPositionDto, PositionEntity>();
        }
    }
}