using FluentValidation;

namespace VSA.Api.Features.Brands.AddBrand
{
    public class AddBrandValidator
    {
        public class Validator : AbstractValidator<AddBrandCommand>
        {
            public Validator()
            {

                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.DisplayText).NotEmpty();
                RuleFor(x => x.Address).NotEmpty();
            }
        }
    }
}
