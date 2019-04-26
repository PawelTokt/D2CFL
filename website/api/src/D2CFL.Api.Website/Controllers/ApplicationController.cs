using System.Collections.Generic;
using System.Net;
using D2CFL.Api.Website.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace D2CFL.Api.Website.Controllers
{
    [AllowAnonymous]
    [Route("api/Applications")]
    public class ApplicationController : Controller
    {
        private readonly IList<Application> _applications;

        public ApplicationController(IOptions<List<Application>> applications)
        {
            _applications = applications.Value;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<Application>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            return Ok(_applications);
        }
    }
}
