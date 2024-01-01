using MediatR;
using VSA.Api.Entities;
using VSA.Api.Infrastructure.Database;
using VSA.Api.Shared;

namespace VSA.Api.Features.Brands.DeleteBrand
{
    public class DeleteBrandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandResponse>
    {
        private readonly AppDbContext _dbContext;
    

        public DeleteBrandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
           
        }

        
        public async Task<DeleteBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _dbContext.Brands.FindAsync(request.Id);

            DeleteBrandResponse brandResponse;

            if (brand is null )
            {

                throw new ErrorException(
                    "DeleteBrand.NotFoundBrandId",
                    "Not Found Brand Id! :) ");
  
            }
            else
            {
                brandResponse = new DeleteBrandResponse
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    DisplayText = brand.DisplayText,
                    Address = brand.Address

                };

                
                _dbContext.Brands.Remove(brand);
                await _dbContext.SaveChangesAsync(cancellationToken);
                
            }

            return brandResponse;
        }
    }

}





