using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace D2CFL.Api.Website.Controllers
{
    [Route("api/Applications")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
