using Carter;
using MediatR;
using VSA.Api.Features.Brands.AddBrand;

namespace VSA.Api.Features.Instrument.AddInstrument
{
    public class AddInstrumentEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/AddInstrument", async (AddInstrumentCommand command, ISender sender) =>
            {
                var response = await sender.Send(command);

                return Results.Ok(response);
            });
        }
    }
}
