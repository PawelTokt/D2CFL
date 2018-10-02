using AutoMapper;
using D2CFL.Business.Organization.Contract.Position;
using D2CFL.Data.Organization.Contract;

namespace D2CFL.Business.Organization.Mappings
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