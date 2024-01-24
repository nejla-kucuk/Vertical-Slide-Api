using FluentValidation;
using MediatR;
using VSA.Api.Features.Brands.UpdateBrand;
using VSA.Api.Infrastructure.Database;
using VSA.Api.Shared;

namespace VSA.Api.Features.Instrument.UpdateInstrument
{
    internal sealed class UpdateInstrumentHandler : IRequestHandler<UpdateInstrumentCommand, UpdateInstrumentResponse>
    {
        private readonly AppDbContext _dbContext;
        private readonly IValidator<UpdateInstrumentCommand> _validator;
        

        public UpdateInstrumentHandler(AppDbContext dbContext, IValidator<UpdateInstrumentCommand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
            
        }

        public async Task<UpdateInstrumentResponse> Handle(UpdateInstrumentCommand request, CancellationToken cancellationToken)
        {

            var validationRequest = _validator.Validate(request);
            if (!validationRequest.IsValid)
            {
                throw new ErrorException(
                    "UpdateInstrument.Validation",
                    "Values are not empty.");
            }



            var instrumentToUpdate = _dbContext.Instruments.Find(request.Id);
            if (instrumentToUpdate is null)
            {
                throw new ErrorException("Id.NotFound", request.Id + ": Instrument Id not found");
            }


            instrumentToUpdate.BrandId = request.BrandId;
            instrumentToUpdate.Model = request.Model;
            instrumentToUpdate.Color = request.Color;
            instrumentToUpdate.ProductionYear = request.ProductionYear;
            instrumentToUpdate.Price = request.Price;
            instrumentToUpdate.ModifiedOn = DateTime.UtcNow;


            _dbContext.SaveChangesAsync();


            var updatedInstrumentModel = new UpdateInstrumentResponse
            {
                BrandId = request.BrandId,
                Model = request.Model,
                Color = request.Color,
                ProductionYear = request.ProductionYear,
                Price = request.Price
            };

            return updatedInstrumentModel;

        }
    }
}
