using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Onyx.Core.Application.Functions.Products;
using Onyx.Product.Api.Controllers;
using System.Threading.Tasks;

namespace Onyx.Products.Api.Controllers
{
    public class ProductController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [Authorize]
        [HttpGet("GetProducts")]
        public async Task<IActionResult> Get()
        {
            var query = new GetProductsQuery();
            return Ok(await _mediator.Send(query));
        }

        [Authorize]
        [HttpGet("GetProductsByColour")]
        public async Task<IActionResult> GetByColor(string colour)
        {
            var query = new GetProductsQuery { colour = colour };
            return Ok(await _mediator.Send(query));
        }
    }
}

