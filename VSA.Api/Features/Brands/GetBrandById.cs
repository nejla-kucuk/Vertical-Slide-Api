using Carter;
using FluentValidation;
using MediatR;
using VSA.Api.Contracts;
using VSA.Api.Database;

namespace VSA.Api.Features.Brands
{
    public static class GetBrandById
    {
        public class Query : IRequest<Result<BrandResponse>>
        {
           public Guid Id { get; set; }     
        }

        internal sealed class Handler: IRequestHandler<Query, <Result<BrandResponse>>
        {
            private readonly AppDbContext _dbContext;

            public Handler(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Result<BrandResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var brandResponse = await _dbContext
                    .Brands
                    .Where(brand => brand.Id == request.Id)
                    .Select(brand => new BrandResponse
                    {
                        Id = brand.Id,
                        Name = brand.Name,
                        DisplayText = brand.DisplayName,
                        Address = brand.Address,
                        CreatedOnUtc = brand.CreatedOnUtc,
                        PublishedOnUtc = brand.PublishedOnUtc

                    })
                    .FirstOrDefaultAsync(cancellationToken);

                if(brandResponse is null)
                {
                    return Result.Failure<BrandResponse>(new Error(
                        "GetBrandById.Null",
                        "ERROR: The brand with the specified ID was not found!"));
                }

                return brandResponse;

            

            }
        }
    }

    public class GetBrandEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           app.MapGet("api/brands/{id}", async(Guid id, ISender sender)=> { 
           
                var query = new GetBrandById.Query { Id = id };

               var result = await sender.Send(query);

               if (result.IsFailure)
               {
                   return Results.NotFound(result.Error);
               }

               return Results.Ok(result);
           });


        }
    }
}
