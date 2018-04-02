using AutoMapper;
using D2CFL.WebSite.Admin.Models;
using D2CFL.Business.League.Contract;

namespace D2CFL.WebSite.Admin.Mappings
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