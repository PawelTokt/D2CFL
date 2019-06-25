using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using D2CFL.Api.Website.Models.FantasyLeague.PlayerStatisticsPerMatch;
using D2CFL.Business.FantasyLeague.Contract.PlayerStatisticsPerMatch;
using Microsoft.AspNetCore.Mvc;

namespace D2CFL.Api.Website.Controllers.FantasyLeague
{
    [Route("api/PlayersStatisticsPerMatch")]
    public class PlayerStatisticsPerMatchController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPlayerStatisticsPerMatchService _playerStatisticsPerMatchService;

        public PlayerStatisticsPerMatchController(IMapper mapper, IPlayerStatisticsPerMatchService playerStatisticsPerMatchService)
        {
            _mapper = mapper;
            _playerStatisticsPerMatchService = playerStatisticsPerMatchService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<PlayerStatisticsPerMatchModel>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IList<PlayerStatisticsPerMatchModel>>(await _playerStatisticsPerMatchService.GetList()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlayerStatisticsPerMatchModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(_mapper.Map<PlayerStatisticsPerMatchModel>(await _playerStatisticsPerMatchService.Get(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlayerStatisticsPerMatchModel), (int) HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] PlayerStatisticsPerMatchActionModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _playerStatisticsPerMatchService.Add(model);

            return Created("", _mapper.Map<PlayerStatisticsPerMatchModel>(item));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PlayerStatisticsPerMatchModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] PlayerStatisticsPerMatchActionModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _playerStatisticsPerMatchService.Edit(id, model);

            return Ok(_mapper.Map<PlayerStatisticsPerMatchModel>(item));
        }
    }
}