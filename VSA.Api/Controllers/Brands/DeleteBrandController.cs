using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSA.Api.Features.Brands.DeleteBrand;

namespace VSA.Api.Controllers.Brands
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteBrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeleteBrandController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public ActionResult<DeleteBrandResponse> DeleteBrand([FromBody] DeleteBrandCommand request)
        {

            var response = _mediator.Send(request);

            return Ok(response);
        }
    }
}
