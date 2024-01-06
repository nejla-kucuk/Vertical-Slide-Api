using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Api.Entities;
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
            var brands = await _dbContext.Brands
                .Include(b => b.Instruments)
                .ToListAsync(cancellationToken);

            var result = brands.SelectMany(brand => brand.Instruments.Select(instrument => new GetAllBrandResponse
            {
                Id = brand.Id,
                Name = brand.Name,
                DisplayText = brand.DisplayText,
                Address = brand.Address,
                CreatedOnUtc = brand.CreatedOn,
                Instruments = new List<Instruments>
                {
                    new Instruments
                    {
                        Model = instrument.Model,
                        Color = instrument.Color,
                        Price = instrument.Price
                        
                    }
                }
            })).ToList();

            return result;
        }

    }
}

    
