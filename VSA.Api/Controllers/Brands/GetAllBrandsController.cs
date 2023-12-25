using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VSA.Api.Features.Brands.Models.Brands;
using VSA.Api.Features.Brands.Queries;

namespace VSA.Api.Controllers.Brands
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllBrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetAllBrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<List<GetAllBrandsModel>>> GetAllBrands()
        {
            var query = new GetAllBrands();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

    }
}
