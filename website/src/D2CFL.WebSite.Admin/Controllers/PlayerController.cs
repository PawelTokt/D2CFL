using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using D2CFL.WebSite.Admin.Models;
using D2CFL.Business.League.Contract;

namespace D2CFL.WebSite.Admin.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public IActionResult Index()
        {
            var players = Mapper.Map<IList<PlayerDto>, List<PlayerViewModel>>(_playerService.GetList());

            return View(players);
        }

        public IActionResult Info(int id)
        {
            var player = Mapper.Map<PlayerDto, PlayerViewModel>(_playerService.Get(id));

            return View(player);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            //ToDo: SelectList teams
            return View();
        }

        [HttpPost]
        public IActionResult Insert(PlayerViewModel playerViewModel)
        {
            var playerDto = Mapper.Map<PlayerViewModel, PlayerDto>(playerViewModel);

            _playerService.Insert(playerDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var playerViewModel = Mapper.Map<PlayerDto, PlayerViewModel>(_playerService.Get(id));

            //ToDo: SelectList teams

            return View(playerViewModel);
        }
        
        [HttpPost]
        public IActionResult Update(PlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _playerService.Update(Mapper.Map<PlayerViewModel, PlayerDto>(model));
            }
            return View(model);
        }
    }
}