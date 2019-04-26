using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using D2CFL.Api.Website.Models.FantasyLeague.Match;
using D2CFL.Business.FantasyLeague.Contract.Match;
using Microsoft.AspNetCore.Mvc;

namespace D2CFL.Api.Website.Controllers.FantasyLeague
{
    [Route("api/Matches")]
    public class MatchController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMatchService _matchService;

        public MatchController(IMapper mapper, IMatchService matchService)
        {
            _mapper = mapper;
            _matchService = matchService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<MatchModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IList<MatchModel>>(await _matchService.GetList()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MatchModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(_mapper.Map<MatchModel>(await _matchService.Get(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(MatchModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] MatchActionModel model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _matchService.Add(model);

            return Created("", _mapper.Map<MatchModel>(item));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MatchModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] MatchActionModel model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _matchService.Edit(id, model);

            return Ok(_mapper.Map<MatchModel>(item));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _matchService.Delete(id);

            return NoContent();
        }
    }
}
