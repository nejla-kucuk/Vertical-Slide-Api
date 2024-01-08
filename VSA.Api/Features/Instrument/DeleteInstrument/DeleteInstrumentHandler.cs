using FluentValidation;
using MediatR;
using VSA.Api.Entities;
using VSA.Api.Features.Brands.DeleteBrand;
using VSA.Api.Features.Instrument.AddInstrument;
using VSA.Api.Infrastructure.Database;
using VSA.Api.Shared;

namespace VSA.Api.Features.Instrument.DeleteInstrument
{
    public class DeleteInstrumentHandler : IRequestHandler< DeleteInstrumentCommand, DeleteInstrumentResponse>
    {
        private readonly AppDbContext _dbContext;

        public DeleteInstrumentHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
           
        }

        public async Task<DeleteInstrumentResponse> Handle(DeleteInstrumentCommand request, CancellationToken cancellationToken)
        {
           var instrument = await _dbContext.Instruments.FindAsync(request.Id);

            if (instrument is  null)
            {
                throw new ErrorException(
                    "DeleteInstrument.NotFoundBrandId",
                    "Not Found Instrument ID! ");
            }

            var instrumentResponse = new DeleteInstrumentResponse
            {
                BrandId = instrument.BrandId,
                Model = instrument.Model,
                Color = instrument.Color,
                ProductionYear = instrument.ProductionYear,
                Price = instrument.Price

            };


            _dbContext.Instruments.Remove(instrument);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return instrumentResponse;
        }
    }
}
