using FluentValidation;
using MediatR;
using VSA.Api.Infrastructure.Database;
using VSA.Api.Shared;

namespace VSA.Api.Features.Brands.UpdateBrand
{
    internal sealed class UpdateBrandHandler : IRequestHandler<UpdateBrandCommand, UpdateBrandResponse>
    {
        private readonly AppDbContext _dbContext;
        private readonly IValidator<UpdateBrandCommand> _validator;

        public UpdateBrandHandler(AppDbContext dbContext, IValidator<UpdateBrandCommand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public Task<UpdateBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {

            var validationRequest = _validator.Validate(request);
            if (!validationRequest.IsValid)
            {
                throw new ErrorException(
                    "UpdateBrand.Validaion",
                    "Values are not empty.");
            }


            var brandToUpdate = _dbContext.Brands.Find(request.Id);
            if (brandToUpdate == null)
            {
                throw new ErrorException("Id.Found", request.Id + ": Brand Id not found");
            }


            brandToUpdate.Name = request.Name;
            brandToUpdate.DisplayText = request.DisplayText;
            brandToUpdate.Address = request.Address;
            brandToUpdate.ModifiedOn = DateTime.UtcNow;


            _dbContext.SaveChangesAsync();


            var updatedBrandModel = new UpdateBrandResponse
            {
                Name = brandToUpdate.Name,
                DisplayText = brandToUpdate.DisplayText,
                Address = brandToUpdate.Address
            };

            return Task.FromResult(updatedBrandModel);

        }
    }
}
