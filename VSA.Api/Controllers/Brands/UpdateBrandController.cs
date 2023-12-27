using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VSA.Api.Features.Brands.Command;
using VSA.Api.Features.Brands.Models;
using VSA.Api.Features.Brands.Queries;

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
        public ActionResult<UpdateBrandModel> GetBrandById([FromBody] UpdateBrand request)
        {
           
            var response = _mediator.Send(request);
            return Ok(response);
        }
    }
}
