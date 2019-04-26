using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using D2CFL.Api.Website.Models.FantasyLeague.Participant;
using D2CFL.Business.FantasyLeague.Contract.Participant;
using Microsoft.AspNetCore.Mvc;

namespace D2CFL.Api.Website.Controllers.FantasyLeague
{
    [Route("api/Participants")]
    public class ParticipantController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IParticipantService _participantService;

        public ParticipantController(IMapper mapper, IParticipantService participantService)
        {
            _mapper = mapper;
            _participantService = participantService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<ParticipantModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IList<ParticipantModel>>(await _participantService.GetList()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ParticipantModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(_mapper.Map<ParticipantModel>(await _participantService.Get(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ParticipantModel), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] ParticipantActionModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _participantService.Add(model);

            return Created("", _mapper.Map<ParticipantModel>(item));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ParticipantModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] ParticipantActionModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _participantService.Edit(id, model);

            return Ok(_mapper.Map<ParticipantModel>(item));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _participantService.Delete(id);

            return NoContent();
        }
    }
}
