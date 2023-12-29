using FluentValidation;
using MediatR;
using System.Diagnostics.Metrics;
using VSA.Api.Database;
using VSA.Api.Entities;
using VSA.Api.Features.Brands.Command;
using VSA.Api.Features.Instrument.Models;
using VSA.Api.Shared;

namespace VSA.Api.Features.Instrument.Command
{
    public class AddInstrument : IRequest<AddInstrumentModel>
    {
        public Guid BrandId { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public DateTime? ProductionYear { get; set; }

        public decimal Price { get; set; }

    }

    public class Validator : AbstractValidator<AddInstrument>
    {
        public Validator()
        {
            RuleFor(x => x.BrandId).NotEmpty();
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
        }
    }


    public class AddInstrumentHandler : IRequestHandler<AddInstrument, AddInstrumentModel>
    {
        private readonly AppDbContext _dbContext;
        private readonly IValidator<AddInstrument> _validator;

        public AddInstrumentHandler(AppDbContext dbContext, IValidator<AddInstrument> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public Task<AddInstrumentModel> Handle(AddInstrument request, CancellationToken cancellationToken)
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

            if (instrument.Brand.Id == request.BrandId) {

                _dbContext.Instruments.Add(instrument);

                _dbContext.SaveChangesAsync(cancellationToken);
            }

            var InstrumentResponse = new AddInstrumentModel
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

}
