using Carter;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using VSA.Api.Entities;
using VSA.Api.Infrastructure.Database;
using VSA.Api.Shared;

namespace VSA.Api.Features.Brands.AddBrand
{

    internal sealed class AddBrandHandler : IRequestHandler<AddBrandCommand, AddBrandResponse>
    {
        private readonly AppDbContext _dbContext;
        private readonly IValidator<AddBrandCommand> _validator;

        public AddBrandHandler(AppDbContext dbContext, IValidator<AddBrandCommand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public async Task<AddBrandResponse> Handle(AddBrandCommand request, CancellationToken cancellationToken)
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

            await _dbContext.SaveChangesAsync(cancellationToken);

            var brandResponse = new AddBrandResponse
            {
                Id = brand.Id,
                Name = brand.Name,
                DisplayText = brand.DisplayText,
                Address = brand.Address
            };

            return brandResponse;
        }

    }
   
    
        
}
