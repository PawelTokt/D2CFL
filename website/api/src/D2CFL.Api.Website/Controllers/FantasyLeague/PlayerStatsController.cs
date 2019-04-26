using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using D2CFL.Api.Website.Models.FantasyLeague.PlayerStats;
using D2CFL.Business.FantasyLeague.Contract.PlayerStats;
using Microsoft.AspNetCore.Mvc;

namespace D2CFL.Api.Website.Controllers.FantasyLeague
{
    [Route("api/PlayerStats")]
    public class PlayerStatsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPlayerStatsService _playerStatsService;

        public PlayerStatsController(IMapper mapper, IPlayerStatsService playerStatsService)
        {
            _mapper = mapper;
            _playerStatsService = playerStatsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<PlayerStatsModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IList<PlayerStatsModel>>(await _playerStatsService.GetList()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlayerStatsModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(_mapper.Map<PlayerStatsModel>(await _playerStatsService.Get(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlayerStatsModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] PlayerStatsActionModel model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _playerStatsService.Add(model);

            return Created("", _mapper.Map<PlayerStatsModel>(item));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PlayerStatsModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] PlayerStatsActionModel model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _playerStatsService.Edit(id, model);

            return Ok(_mapper.Map<PlayerStatsModel>(item));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _playerStatsService.Delete(id);

            return NoContent();
        }
    }
}
