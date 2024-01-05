using FluentValidation;
using MediatR;
using VSA.Api.Entities;
using VSA.Api.Infrastructure.Database;
using VSA.Api.Shared;

namespace VSA.Api.Features.Instrument.AddInstrument
{
    public class AddInstrumentHandler : IRequestHandler<AddInstrumentCommand, AddInstrumentResponse>
    {
        private readonly AppDbContext _dbContext;
        private readonly IValidator<AddInstrumentCommand> _validator;

        public AddInstrumentHandler(AppDbContext dbContext, IValidator<AddInstrumentCommand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public Task<AddInstrumentResponse> Handle(AddInstrumentCommand request, CancellationToken cancellationToken)
        {
            var validationRequest = _validator.Validate(request);
            if (!validationRequest.IsValid)
            {
                throw new ErrorException(
                    "AddInstrument.Validaion",
                    "Values are not empty.");
            }


            var instrument = new Instruments
            {
                Id = Guid.NewGuid(),
                BrandId = request.BrandId,
                Model = request.Model,
                Color = request.Color,
                ProductionYear = request.ProductionYear,
                Price = request.Price,
                CreatedOn = DateTime.UtcNow
            };

            if (instrument.Brand.Id == request.BrandId)
            {

                _dbContext.Instruments.Add(instrument);

                _dbContext.SaveChangesAsync(cancellationToken);
            }

            var InstrumentResponse = new AddInstrumentResponse
            {
                BrandId = instrument.BrandId,
                Model = instrument.Model,
                Color = instrument.Color,
                ProductionYear = instrument.ProductionYear,
                Price = instrument.Price
            };



            return Task.FromResult(InstrumentResponse);
        }
    }
