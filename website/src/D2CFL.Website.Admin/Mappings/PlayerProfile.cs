using AutoMapper;
using D2CFL.Website.Admin.Models;
using D2CFL.Business.League.Contract;

namespace D2CFL.Website.Admin.Mappings
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerDto, PlayerViewModel>();

            CreateMap<PlayerViewModel, PlayerDto>();
        }
    }
}