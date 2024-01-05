using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSA.Api.Features.Instrument.AddInstrument;

namespace VSA.Api.Controllers.Instrument
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddInstrumentController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AddInstrumentController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public ActionResult<AddInstrumentResponse> AddBrand([FromBody] AddInstrumentCommand request)
        {

            var response = _mediator.Send(request);

            return Ok(response);
        }
    }
}
