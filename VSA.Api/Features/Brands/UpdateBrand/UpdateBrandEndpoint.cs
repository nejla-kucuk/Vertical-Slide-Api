using Carter;
using MediatR;


namespace VSA.Api.Features.Brands.UpdateBrand
{
    public class UpdateBrandEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/UpdateBrand", async (UpdateBrandCommand command, ISender sender) =>
            {
                var response = await sender.Send(command);

                return Results.Ok(response);
            });
        }
    }
    
}
