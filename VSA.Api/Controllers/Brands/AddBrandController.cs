using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSA.Api.Features.Brands.AddBrand;

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
        public ActionResult<AddBrandResponse> AddBrand([FromBody] AddBrand request)
        { 

            var response = _mediator.Send(request);

            return Ok(response);
        }
    }
}
