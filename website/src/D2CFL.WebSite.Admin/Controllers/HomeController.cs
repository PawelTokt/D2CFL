using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using D2CFL.WebSite.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using D2CFL.Business.League.Contract;

namespace D2CFL.WebSite.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayerService _playerService;
        
        public HomeController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<IActionResult> Index()
        {
            var players = Mapper.Map<IList<PlayerDto>, List<PlayerViewModel>>(await _playerService.GetList());
            return View(players);
        }
    }
}