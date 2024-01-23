using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSA.Api.Features.Brands.AddBrand;
using VSA.Api.Features.Brands.UpdateBrand;

namespace VSA.Api.Features.Brands.DeleteBrand
{
    public class DeleteBrandEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapPost("api/DeleteBrandById", async ([FromQuery] Guid id, ISender sender) =>
            {
                var response = await sender.Send(new DeleteBrandCommand { Id = id });

                return Results.Ok(response);
            });
        }
    }
    
}
