using Carter;
using MediatR;
using VSA.Api.Features.Instrument.AddInstrument;

namespace VSA.Api.Features.Instrument.DeleteInstrument
{
    public class DeleteInstrumentEndpoint: ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/deleteinstrument", async (DeleteInstrumentCommand command, ISender sender) =>
            {
                var response = await sender.Send(command);

                return Results.Ok(response);
            });
        }
    }
}
