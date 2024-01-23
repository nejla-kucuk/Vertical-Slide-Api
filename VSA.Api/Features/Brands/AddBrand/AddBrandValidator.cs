using FluentValidation;

namespace VSA.Api.Features.Brands.AddBrand
{
    public class AddBrandValidator
    {
        public class Validator : AbstractValidator<AddBrandCommand>
        {
            public Validator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Name is required.")
                    .Length(5, 50).WithMessage("Name must be between 5 and 50 characters.");

                RuleFor(x => x.DisplayText)
                    .NotEmpty().WithMessage("DisplayText is required.")
                    .Length(5, 100).WithMessage("DisplayText must be between 5 and 100 characters.");

                RuleFor(x => x.Address)
                    .NotEmpty().WithMessage("Address is required.")
                    .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.");
            }
        }
    }
}
