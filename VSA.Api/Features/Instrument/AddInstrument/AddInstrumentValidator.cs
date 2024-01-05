using FluentValidation;

namespace VSA.Api.Features.Instrument.AddInstrument
{
    public class Validator : AbstractValidator<AddInstrumentCommand>
    {
        public Validator()
        {
            RuleFor(x => x.BrandId).NotEmpty();
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
        }
    }
}
