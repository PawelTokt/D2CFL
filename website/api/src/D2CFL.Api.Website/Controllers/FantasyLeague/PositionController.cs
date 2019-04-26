using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using D2CFL.Api.Website.Models.FantasyLeague.Position;
using D2CFL.Business.FantasyLeague.Contract.Position;
using Microsoft.AspNetCore.Mvc;

namespace D2CFL.Api.Website.Controllers.FantasyLeague
{
    [Route("api/Positions")]
    public class PositionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPositionService _positionService;

        public PositionController(IMapper mapper, IPositionService positionService)
        {
            _mapper = mapper;
            _positionService = positionService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<PositionModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IList<PositionModel>>(await _positionService.GetList()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PositionModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(_mapper.Map<PositionModel>(await _positionService.Get(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(PositionModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] PositionActionModel model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _positionService.Add(model);

            return Created("", _mapper.Map<PositionModel>(item));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PositionModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] PositionActionModel model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _positionService.Edit(id, model);

            return Ok(_mapper.Map<PositionModel>(item));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _positionService.Delete(id);

            return NoContent();
        }
    }
}
