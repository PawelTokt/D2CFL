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

        [HttpGet]
        public IActionResult Insert()
        {
            //ToDo: SelectList teams
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(PlayerViewModel model)
        {
            var playerDto = Mapper.Map<PlayerViewModel, PlayerDto>(model);
            await _playerService.Insert(playerDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            //ToDo: SelectList teams
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(PlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _playerService.Update(Mapper.Map<PlayerViewModel, PlayerDto>(model));
            }
            return View(model);
        }
    }
}