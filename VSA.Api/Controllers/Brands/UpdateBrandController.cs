using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VSA.Api.Features.Brands.UpdateBrand;

namespace VSA.Api.Controllers.Brands
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateBrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateBrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public ActionResult<UpdateBrandResponse> GetBrandById([FromBody] UpdateBrandCommand request)
        {
           
            var response = _mediator.Send(request);
            return Ok(response);
        }
    }
}
