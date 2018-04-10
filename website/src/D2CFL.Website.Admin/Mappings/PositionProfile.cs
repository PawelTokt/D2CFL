using AutoMapper;
using D2CFL.Website.Admin.Models;
using D2CFL.Business.League.Contract;

namespace D2CFL.Website.Admin.Mappings
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<PositionDto, PositionViewModel>();

            CreateMap<PositionViewModel, PositionDto>();
        }
    }
}