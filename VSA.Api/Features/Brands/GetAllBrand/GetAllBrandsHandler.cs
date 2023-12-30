using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Api.Infrastructure.Database;

namespace VSA.Api.Features.Brands.GetAllBrand
{

    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, List<GetAllBrandResponse>>
    {
        private readonly AppDbContext _dbContext;

        public GetAllBrandsHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<List<GetAllBrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _dbContext.Brands.ToListAsync(cancellationToken);

            var result = brands.Select(brand => new GetAllBrandResponse
            {
                Id = brand.Id,
                Name = brand.Name,
                DisplayText = brand.DisplayText,
                Address = brand.Address,
                CreatedOnUtc = brand.CreatedOn
            }).ToList();

            return result;
        }

    }
}

    
