using FluentValidation;

namespace VSA.Api.Features.Brands.UpdateBrand
{
    public class UpdateBrandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandValidator()
        {

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DisplayText).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
