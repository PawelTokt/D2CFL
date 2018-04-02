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

        public async Task<IActionResult> Info()
        {
            var player = Mapper.Map<TeamDto, TeamViewModel>(await _teamService.Get());

            return View(player);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(TeamViewModel teamViewModel)
        {
            if (!ModelState.IsValid) return View(teamViewModel);

            var teamDto = Mapper.Map<TeamViewModel, TeamDto>(teamViewModel);

            _teamService.Insert(teamDto);

            return RedirectToAction("Index");
        }
    }
}