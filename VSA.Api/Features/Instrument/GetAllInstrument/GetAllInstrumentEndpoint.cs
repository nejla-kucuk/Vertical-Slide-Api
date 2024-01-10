using Carter;
using MediatR;

namespace VSA.Api.Features.Instrument.GetAllInstrument
{
    public class GetAllInstrumentEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/GetAllInstrument", async (ISender sender) =>
            {
                var query = new GetAllInstrumentQuery();

                var response = await sender.Send(query);

                return Results.Ok(response);
            });
        }
    }
}
