using FluentValidation;

namespace VSA.Api.Features.Instrument.UpdateInstrument
{
    public class UpdateInstrumentValidator
    {
        public class Validator : AbstractValidator<UpdateInstrumentCommand>
        {
            public Validator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.BrandId).NotEmpty();  
                RuleFor(x => x.Model).NotEmpty();
                RuleFor(x => x.Color).NotEmpty();
                RuleFor(x => x.Price).NotEmpty();
            }
        }
    }
}
