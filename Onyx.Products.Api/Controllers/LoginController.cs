
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Onyx.Core.Application.Common;
using Onyx.Core.Application.Functions.Auth;
using Onyx.Product.Api.Controllers;
using System.Threading.Tasks;

namespace Onyx.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ApiControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            var query = new GetTokenQuery { UserLogin = userLogin };
            return Ok(await Mediator.Send(query));
        }        
    }
}
