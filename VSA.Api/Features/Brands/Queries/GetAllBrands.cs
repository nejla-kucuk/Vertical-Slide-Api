using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Api.Database;
using VSA.Api.Features.Brands.Command;
using VSA.Api.Features.Brands.Models.Brands;

namespace VSA.Api.Features.Brands.Queries
{
    public class GetAllBrands : IRequest<List<GetAllBrandsModel>>
    {

    }

    public class GetAllBrandsHandler : IRequestHandler<GetAllBrands, List<GetAllBrandsModel>>
    {
        private readonly AppDbContext _dbContext;

        public GetAllBrandsHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<List<GetAllBrandsModel>> Handle(GetAllBrands request, CancellationToken cancellationToken)
        {
            var brands = await _dbContext.Brands.ToListAsync(cancellationToken);

            var result = brands.Select(brand => new GetAllBrandsModel
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
