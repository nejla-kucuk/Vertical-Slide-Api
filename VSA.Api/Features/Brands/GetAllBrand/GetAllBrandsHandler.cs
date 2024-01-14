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
               
                  
                    
               InstrumentModel = instrument.Model,
               InstrumentColor = instrument.Color,
               InstrumentProductionYear = instrument.ProductionYear,
               InstrumentPrice = instrument.Price
                        
                    
                
            })).ToList();

            return result;
        }

    }
}

    
