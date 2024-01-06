using Carter;
using MediatR;

namespace VSA.Api.Features.Brands.AddBrand
{
    public class AddBrandEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/AddBrand", async (AddBrandCommand command, ISender sender) =>
            {
                var response = await sender.Send(command);

                return Results.Ok(response);
            });
        }
    }
}
