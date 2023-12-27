using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSA.Api.Features.Brands.Command;
using VSA.Api.Features.Brands.Models;

namespace VSA.Api.Controllers.Brands
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddBrandController : Controller
    {
        private readonly IMediator _mediator;

        public AddBrandController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public ActionResult<AddBrandModel> AddBrand([FromBody] AddBrand request)
        { 

            var response = _mediator.Send(request);

            return Ok(response);
        }
    }
}
