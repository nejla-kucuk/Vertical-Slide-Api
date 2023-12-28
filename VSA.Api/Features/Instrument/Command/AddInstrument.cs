using FluentValidation;
using MediatR;
using VSA.Api.Database;
using VSA.Api.Features.Brands.Command;
using VSA.Api.Features.Instrument.Models;

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
            throw new NotImplementedException();
        }
    }

}
