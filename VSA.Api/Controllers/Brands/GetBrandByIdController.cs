﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSA.Api.Features.Brands.Models;
using VSA.Api.Features.Brands.Queries;

namespace VSA.Api.Controllers.Brands
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBrandByIdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetBrandByIdController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{id:guid}")]
        public ActionResult<GetBrandByIdModel> GetBrandById([FromRoute] Guid id)
        {
            var request = new GetBrandByIdQ { Id = id };
            var response = _mediator.Send(request);
            return Ok(response);
        }


    }
}