using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using VSA.Api.Entities;
using VSA.Api.Features.Brands.GetAllBrand;
using VSA.Api.Features.Instrument.AddInstrument;
using VSA.Api.Infrastructure.Database;

namespace VSA.Api.Features.Instrument.GetAllInstrument
{
    internal sealed class GetAllInstrumentHandler : IRequestHandler<GetAllInstrumentQuery, List<GetAllInstrumentResponse>>
    {

        private readonly AppDbContext _dbContext;

        public GetAllInstrumentHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetAllInstrumentResponse>> Handle(GetAllInstrumentQuery request, CancellationToken cancellationToken)
        {
            var instruments = await _dbContext.Instruments
                .Include(b => b.Brand)
                .ToListAsync(cancellationToken);

            var result = instruments.Select(instrument => new GetAllInstrumentResponse
            {
               BrandId = instrument.Id,
               BrandName = instrument.Brand.Name,
               BrandDisplayText = instrument.Brand.DisplayText,
               BrandAddress = instrument.Brand.Address,
               Model = instrument.Model,
               Color = instrument.Color,
               ProductionYear = instrument.ProductionYear,
               Price = instrument.Price
            


            }).ToList();

            return result;
        }
    }
}