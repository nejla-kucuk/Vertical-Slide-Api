using Carter;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using VSA.Api.Contracts;
using VSA.Api.Database;
using VSA.Api.Shared;

namespace VSA.Api.Features.Brands
{
    public static class GetBrandById
    {
        public class Query : IRequest<BrandResponse>
        {
           public Guid Id { get; set; }     
        }

        internal sealed class Handler: IRequestHandler<Query, BrandResponse>
        {
            private readonly AppDbContext _dbContext;

            public Handler(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<BrandResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var brandResponse = await _dbContext
                    .Brands
                    .Where(brand => brand.Id == request.Id)
                    .Select(brand => new BrandResponse
                    {
                        Id = brand.Id,
                        Name = brand.Name,
                        DisplayText = brand.DisplayText,
                        Address = brand.Address,
                        CreatedOnUtc = brand.CreatedOn

                    })
                    .FirstOrDefaultAsync(cancellationToken);

                if(brandResponse is null)
                {
                    throw new ErrorException(
                                "GetBrandById.Null",
                                "ERROR: The brand with the specified ID was not found!");
                }

                return brandResponse;

            

            }
        }
    }

    public class GetBrandEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/brands/{id}", async (Guid id, HttpContext context) =>
            {
                var query = new GetBrandById.Query { Id = id };

                var sender = context.RequestServices.GetRequiredService<ISender>();

                var result = await sender.Send(query);

                if (result is null)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    await context.Response.WriteAsJsonAsync(new { Error = "Result.Null" });
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    await context.Response.WriteAsJsonAsync(result);
                }
            });
        }
    }

}
