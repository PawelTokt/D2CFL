using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using D2CFL.Api.Website.Models.FantasyLeague.Tournament;
using D2CFL.Business.FantasyLeague.Contract.Tournament;
using Microsoft.AspNetCore.Mvc;

namespace D2CFL.Api.Website.Controllers.FantasyLeague
{
    [Route("api/Tournaments")]
    public class TournamentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITournamentService _tournamentService;

        public TournamentController(IMapper mapper, ITournamentService tournamentService)
        {
            _mapper = mapper;
            _tournamentService = tournamentService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<TournamentModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IList<TournamentModel>>(await _tournamentService.GetList()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TournamentModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(_mapper.Map<TournamentModel>(await _tournamentService.Get(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(TournamentModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] TournamentActionModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _tournamentService.Add(model);

            return Created("", _mapper.Map<TournamentModel>(item));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TournamentModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] TournamentActionModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _tournamentService.Edit(id, model);

            return Ok(_mapper.Map<TournamentModel>(item));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _tournamentService.Delete(id);

            return NoContent();
        }
    }
}