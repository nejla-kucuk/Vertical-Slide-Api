using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection;
using VSA.Api.Database;
using VSA.Api.Entities;

namespace VSA.Api.Features.Brands
{
    public static class AddBrand
    {
        public class Command : IRequest<Guid>
        {
            public string Name { get; set; }

            public string DisplayText { get; set; }

            public string Address { get; set; }
        }

        internal sealed class Handler : IRequestHandler<Command, Guid>
        {
            private readonly AppDbContext _dbContext;

            public Handler(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var brand = new Brand
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    DisplayText = request.DisplayText,
                    Address = request.Address,
                    CreatedOn = DateTime.UtcNow
                };

                _dbContext.Add(brand);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return brand.Id;
            }
        }

        public class Endpoint : ICarterModule
        {
            public void AddRoutes(IEndpointRouteBuilder app)
            {
                app.MapPost("api/brands", async (Command command, ISender sender) =>
                {
                    var brandId = await sender.Send(command);

                    return Results.Ok(brandId);
                });
            }
        }



    }
}
