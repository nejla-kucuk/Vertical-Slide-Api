using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Api.Database;
using VSA.Api.Features.Brands.Models.Brands;
using VSA.Api.Shared;

namespace VSA.Api.Features.Brands.Queries
{
    public class GetBrandByIdQ : IRequest<GetBrandByIdModel>
    {
        public Guid Id { get; set; }
    }

    public class GetBrandByIdHandler : IRequestHandler<GetBrandByIdQ, GetBrandByIdModel>
    {
        private readonly AppDbContext _dbContext;

        public GetBrandByIdHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
           
        }

        public async Task<GetBrandByIdModel> Handle(GetBrandByIdQ request, CancellationToken cancellationToken)
        {
            var brandResponse = await _dbContext
                   .Brands
                   .Where(b => b.Id == request.Id)
                   .Select(b => new GetBrandByIdModel
                   {
                       Name = b.Name,
                       DisplayText = b.DisplayText,
                       Address = b.Address,
                       CreatedOnUtc = b.CreatedOn
                   })
                   .FirstOrDefaultAsync(cancellationToken);

             if (brandResponse is null)
             {
                throw new ErrorException(
                            "GetBrandById.Null",
                            "ERROR: The brand with the specified ID was not found!");
             }

            return brandResponse;
        }
    }
}
