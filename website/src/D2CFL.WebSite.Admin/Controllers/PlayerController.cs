using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using D2CFL.Business.League.Contract;
using D2CFL.WebSite.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace D2CFL.WebSite.Admin.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<IActionResult> Index()
        {
            var players = Mapper.Map<IList<PlayerDto>, List<PlayerViewModel>>(await _playerService.GetList());
            return View(players);
        }

        public async Task<IActionResult> Update()
        {
            return View();
        }
    }
}