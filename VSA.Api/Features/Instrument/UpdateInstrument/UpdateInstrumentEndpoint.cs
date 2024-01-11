using Carter;
using MediatR;
using VSA.Api.Features.Brands.UpdateBrand;

namespace VSA.Api.Features.Instrument.UpdateInstrument
{
    public class UpdateInstrumentEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/UpdateInstrument", async (UpdateInstrumentCommand command, ISender sender) =>
            {
                var response = await sender.Send(command);

                return Results.Ok(response);
            });
        }
    }
}
