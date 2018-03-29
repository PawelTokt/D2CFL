using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using D2CFL.WebSite.Admin.Models;
using System.Collections.Generic;
using D2CFL.Business.League.Contract;

namespace D2CFL.WebSite.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayerSerivice _playerSerivice;
        
        public HomeController(IPlayerSerivice playerSerivice)
        {
            _playerSerivice = playerSerivice;
        }

        public IActionResult Index()
        {
            var players = Mapper.Map<IList<PlayerDto>, List<PlayerViewModel>>(_playerSerivice.GetList());

            return View(players);
        }
    }
}