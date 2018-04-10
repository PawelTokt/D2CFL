using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using D2CFL.Website.Admin.Models;
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
        public async Task<IActionResult> Insert(PlayerViewModel playerViewModel)
        {
            if (!ModelState.IsValid) return View(playerViewModel);

            var playerDto = Mapper.Map<PlayerViewModel, PlayerDto>(playerViewModel);

            await _playerService.Insert(playerDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var playerViewModel = Mapper.Map<PlayerDto, PlayerViewModel>(await _playerService.Get(id));

            ViewBag.Teams = new SelectList(await _teamService.GetList(), "Id", "Name");

            ViewBag.Positions = new SelectList(await _positionService.GetList(), "Id", "Name");

            return View(playerViewModel);
        }

        [HttpPost]
        public IActionResult Update(PlayerViewModel playerViewModel)
        {
            if (!ModelState.IsValid) return View(playerViewModel);

            _playerService.Update(Mapper.Map<PlayerViewModel, PlayerDto>(playerViewModel));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var playerViewModel = Mapper.Map<PlayerDto, PlayerViewModel>(await _playerService.Get(id));

            if (playerViewModel != null)
            {
                return View(playerViewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerViewModel = Mapper.Map<PlayerDto, PlayerViewModel>(await _playerService.Get(id));

            var playerDto = Mapper.Map<PlayerViewModel, PlayerDto>(playerViewModel);

            _playerService.Delete(playerDto);

            return RedirectToAction("Index");
        }
    }
}