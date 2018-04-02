using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using D2CFL.WebSite.Admin.Models;
using D2CFL.Business.League.Contract;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace D2CFL.WebSite.Admin.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;
        private readonly IPositionService _positionService;

        public PlayerController(IPlayerService playerService, ITeamService teamService, IPositionService positionService)
        {
            _playerService = playerService;
            _teamService = teamService;
            _positionService = positionService;
        }

        public async Task<IActionResult> Index()
        {
            var players = Mapper.Map<IList<PlayerDto>, List<PlayerViewModel>>(await _playerService.GetList());

            return View(players);
        }

        public async Task<IActionResult> Info(int id)
        {
            var player = Mapper.Map<PlayerDto, PlayerViewModel>(await _playerService.Get(id));

            return View(player);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            ViewBag.Teams = new SelectList(await _teamService.GetList(), "Id", "Name");

            ViewBag.Positions = new SelectList(await _positionService.GetList(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Insert(PlayerViewModel playerViewModel)
        {
            if (!ModelState.IsValid) return View(playerViewModel);

            var playerDto = Mapper.Map<PlayerViewModel, PlayerDto>(playerViewModel);

            _playerService.Insert(playerDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            //ToDo: SelectList teams

            return View();
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