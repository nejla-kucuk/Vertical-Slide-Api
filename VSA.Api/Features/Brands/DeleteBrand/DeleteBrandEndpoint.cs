using Carter;
using MediatR;
using VSA.Api.Features.Brands.AddBrand;
using VSA.Api.Features.Brands.UpdateBrand;

namespace VSA.Api.Features.Brands.DeleteBrand
{
    public class DeleteBrandEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapPost("api/DeleteBrand", async (DeleteBrandCommand command, ISender sender) =>
            {
                var response = await sender.Send(command);

                return Results.Ok(response);
            });
        }
    }
    
}
