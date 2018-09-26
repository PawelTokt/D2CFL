using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using D2CFL.Api.Website.Models.Organization.Organization;
using D2CFL.Business.Organization.Contract.Organization;
using Microsoft.AspNetCore.Mvc;

namespace D2CFL.Api.Website.Controllers.Organization
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
        [ProducesResponseType(typeof(IList<OrganizationModel>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(_mapper.Map<OrganizationModel>(await _organizationService.Get(id)));
        }
    }
}
