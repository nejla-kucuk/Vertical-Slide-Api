using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSA.Api.Contracts;

namespace VSA.Api.Controllers.Brands
{
    [ApiController]
    [Route("[controller]")]
    public class AddBrandController : Controller
    {
        private readonly IMediator _mediator;

        public AddBrandController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public ActionResult<BrandResponse> AddBrand([FromBody] AddBrandRequest request)
        {

            var response = _mediator.Send(request);

            return Ok(response);
        }
    }
}
