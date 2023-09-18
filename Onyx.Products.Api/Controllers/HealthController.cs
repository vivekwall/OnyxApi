using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Onyx.Products.Api.Controllers
{
    public class HealthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("/")]
        public ActionResult HealthCheck()
        {
            return Ok("Ok");
        }
    }
}
