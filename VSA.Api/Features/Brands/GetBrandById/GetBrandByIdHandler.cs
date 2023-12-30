using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Api.Infrastructure.Database;
using VSA.Api.Shared;

namespace VSA.Api.Features.Brands.GetBrandById
{
    public class GetBrandByIdHandler : IRequestHandler<GetBrandByIdQ, GetBrandByIdModelResponse>
    {
        private readonly AppDbContext _dbContext;

        public GetBrandByIdHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<GetBrandByIdModelResponse> Handle(GetBrandByIdQ request, CancellationToken cancellationToken)
        {
            var brandResponse = await _dbContext
                   .Brands
                   .Where(b => b.Id == request.Id)
                   .Select(b => new GetBrandByIdModelResponse
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
