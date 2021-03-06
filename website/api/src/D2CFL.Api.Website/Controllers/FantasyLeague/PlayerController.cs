﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using D2CFL.Api.Website.Models.FantasyLeague.Player;
using D2CFL.Api.Website.Models.FantasyLeague.PlayerStatistics;
using D2CFL.Business.FantasyLeague.Contract.Player;
using Microsoft.AspNetCore.Mvc;

namespace D2CFL.Api.Website.Controllers.FantasyLeague
{
    [Route("api/Players")]
    public class PlayerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPlayerService _playerService;

        public PlayerController(IMapper mapper, IPlayerService playerService)
        {
            _mapper = mapper;
            _playerService = playerService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<PlayerModel>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IList<PlayerModel>>(await _playerService.GetList()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlayerModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(_mapper.Map<PlayerModel>(await _playerService.Get(id)));
        }

        [HttpGet("{id}/Statistics")]
        [ProducesResponseType(typeof(PlayerStatisticsModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetStatistics(Guid id)
        {
            return Ok(_mapper.Map<PlayerStatisticsModel>(await _playerService.GetStatistics(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlayerModel), (int) HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] PlayerActionModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _playerService.Add(model);

            return Created("", _mapper.Map<PlayerModel>(item));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PlayerModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] PlayerActionModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _playerService.Edit(id, model);

            return Ok(_mapper.Map<PlayerModel>(item));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _playerService.Delete(id);

            return NoContent();
        }
    }
}