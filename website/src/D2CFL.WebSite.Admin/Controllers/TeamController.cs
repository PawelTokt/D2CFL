using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using D2CFL.WebSite.Admin.Models;
using System.Collections.Generic;
using D2CFL.Business.League.Contract;

namespace D2CFL.WebSite.Admin.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IActionResult> Index()
        {
            var players = Mapper.Map<IList<TeamDto>, List<TeamViewModel>>(await _teamService.GetList());

            return View(players);
        }

        public async Task<IActionResult> Info(int id)
        {
            var player = Mapper.Map<TeamDto, TeamViewModel>(await _teamService.Get(id));

            return View(player);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(TeamViewModel teamViewModel)
        {
            if (!ModelState.IsValid) return View(teamViewModel);

            var teamDto = Mapper.Map<TeamViewModel, TeamDto>(teamViewModel);

            await _teamService.Insert(teamDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var teamViewModel = Mapper.Map<TeamDto, TeamViewModel>(await _teamService.Get(id));

            return View(teamViewModel);
        }

        [HttpPost]
        public IActionResult Update(TeamViewModel teamViewModel)
        {
            if (!ModelState.IsValid) return View(teamViewModel);

            _teamService.Update(Mapper.Map<TeamViewModel, TeamDto>(teamViewModel));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var teamViewModel = Mapper.Map<TeamDto, TeamViewModel>(await _teamService.Get(id));

            if (teamViewModel != null)
            {
                return View(teamViewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamViewModel = Mapper.Map<TeamDto, TeamViewModel>(await _teamService.Get(id));

            var teamDto = Mapper.Map<TeamViewModel, TeamDto>(teamViewModel);

            _teamService.Delete(teamDto);

            return RedirectToAction("Index");
        }
    }
}