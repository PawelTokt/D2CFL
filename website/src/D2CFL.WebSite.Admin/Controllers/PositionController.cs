using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using D2CFL.WebSite.Admin.Models;
using System.Collections.Generic;
using D2CFL.Business.League.Contract;

namespace D2CFL.WebSite.Admin.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        public async Task<IActionResult> Index()
        {
            var positions = Mapper.Map<IList<PositionDto>, List<PositionViewModel>>(await _positionService.GetList());

            return View(positions);
        }

        public async Task<IActionResult> Info(int id)
        {
            var position = Mapper.Map<PositionDto, PositionViewModel>(await _positionService.Get(id));

            return View(position);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(PositionViewModel positionViewModel)
        {
            if (!ModelState.IsValid) return View(positionViewModel);

            var positionDto = Mapper.Map<PositionViewModel, PositionDto>(positionViewModel);

            await _positionService.Insert(positionDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var positionViewModel = Mapper.Map<PositionDto, PositionViewModel>(await _positionService.Get(id));

            return View(positionViewModel);
        }

        [HttpPost]
        public IActionResult Update(PositionViewModel positionViewModel)
        {
            if (!ModelState.IsValid) return View(positionViewModel);

            _positionService.Update(Mapper.Map<PositionViewModel, PositionDto>(positionViewModel));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var positionViewModel = Mapper.Map<PositionDto, PositionViewModel>(await _positionService.Get(id));

            if (positionViewModel != null)
            {
                return View(positionViewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var positionViewModel = Mapper.Map<PositionDto, PositionViewModel>(await _positionService.Get(id));

            var positionDto = Mapper.Map<PositionViewModel, PositionDto>(positionViewModel);

            _positionService.Delete(positionDto);

            return RedirectToAction("Index");
        }
    }
}