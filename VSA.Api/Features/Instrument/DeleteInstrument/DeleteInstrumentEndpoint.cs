using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSA.Api.Features.Instrument.AddInstrument;

namespace VSA.Api.Features.Instrument.DeleteInstrument
{
    public class DeleteInstrumentEndpoint: ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/DeleteInstrumentById", async ([FromQuery] Guid id, ISender sender) =>
            {
                var response = await sender.Send(new DeleteInstrumentCommand { Id = id });

                return Results.Ok(response);
            });
        }
    }
}
