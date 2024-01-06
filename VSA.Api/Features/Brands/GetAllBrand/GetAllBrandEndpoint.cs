using Carter;
using MediatR;
using VSA.Api.Features.Brands.AddBrand;

namespace VSA.Api.Features.Brands.GetAllBrand
{
    public class GetAllBrandEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapGet("api/GetAllBrands", async (ISender sender) =>
            {
                var query = new GetAllBrandsQuery();

                var response = await sender.Send(query);

                return Results.Ok(response);
            });
        }
    }
}
