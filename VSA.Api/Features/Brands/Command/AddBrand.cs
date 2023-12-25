using FluentValidation;
using MediatR;
using VSA.Api.Database;
using VSA.Api.Entities;
using VSA.Api.Features.Brands.Models.Brands;
using VSA.Api.Shared;


namespace VSA.Api.Features.Brands.Command
{
    public class AddBrand : IRequest<AddBrandModel>
    {
        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }
    }

    public class Validator : AbstractValidator<AddBrand>
    {
        public Validator()
        {

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DisplayText).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
        }
    }

    public class AddBrandHandler : IRequestHandler<AddBrand, AddBrandModel>
    {
        private readonly AppDbContext _dbContext;
        private readonly IValidator<AddBrand> _validator;

        public AddBrandHandler(AppDbContext dbContext, IValidator<AddBrand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public Task<AddBrandModel> Handle(AddBrand request, CancellationToken cancellationToken)
        {
            var validationRequest = _validator.Validate(request);
            if (!validationRequest.IsValid)
            {
                throw new ErrorException(
                    "AddBrand.Validaion",
                    "Values are not empty.");
            }

            var brand = new Brand
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                DisplayText = request.DisplayText,
                Address = request.Address,
                CreatedOn = DateTime.UtcNow
            };

            _dbContext.Brands.Add(brand);

            _dbContext.SaveChangesAsync(cancellationToken);

            var brandResponse = new AddBrandModel
            {
                Id = brand.Id,
                Name = brand.Name,
                DisplayText = brand.DisplayText,
                Address = brand.Address
            };

            return Task.FromResult(brandResponse);
        }
    }
}
