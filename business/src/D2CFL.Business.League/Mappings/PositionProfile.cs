using AutoMapper;
using D2CFL.Data.League.Contract;
using D2CFL.Business.League.Contract;

namespace D2CFL.Business.League.Mappings
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<PositionEntity, PositionDto>();

            CreateMap<PositionDto, PositionEntity>();
        }

    }
}