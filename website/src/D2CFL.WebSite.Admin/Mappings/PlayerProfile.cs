using AutoMapper;
using D2CFL.WebSite.Admin.Models;
using D2CFL.Business.League.Contract;

namespace D2CFL.WebSite.Admin.Mappings
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerDto, PlayerViewModel>();
        }
    }
}