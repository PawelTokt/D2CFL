using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using D2CFL.Api.Website.Models.FantasyLeague.Organization;
using D2CFL.Business.FantasyLeague.Contract.Organization;
using Microsoft.AspNetCore.Mvc;

namespace D2CFL.Api.Website.Controllers.FantasyLeague
{
    [Route("api/Organizations")]
    public class OrganizationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IMapper mapper, IOrganizationService organizationService)
        {
            _mapper = mapper;
            _organizationService = organizationService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<OrganizationModel>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<IList<OrganizationModel>>(await _organizationService.GetList()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrganizationModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(_mapper.Map<OrganizationModel>(await _organizationService.Get(id)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrganizationModel), (int) HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] OrganizationActionModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _organizationService.Add(model);

            return Created("", _mapper.Map<OrganizationModel>(item));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OrganizationModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] OrganizationActionModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var item = await _organizationService.Edit(id, model);

            return Ok(_mapper.Map<OrganizationModel>(item));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _organizationService.Delete(id);

            return NoContent();
        }
    }
}