using MediatR;
using VSA.Api.Infrastructure.Database;
using VSA.Api.Shared;

namespace VSA.Api.Features.Brands.DeleteBrand
{
    public class DeleteBrandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandResponse>
    {
        private readonly AppDbContext _dbContext;
        private readonly Util _util;

        public DeleteBrandHandler(AppDbContext dbContext, Util util)
        {
            _dbContext = dbContext;
            _util = util;
        }

        public async Task<DeleteBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brandExists = await _util.BrandIdExist(request.Id);

            if (brandExists)
            {
                var brand = await _dbContext.Brands.FindAsync(request.Id);

                if (brand != null)
                {
                    _dbContext.Brands.Remove(brand);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }
            }
            else
            {
                throw new ErrorException(
                    "DeleteBrand.NotFoundBrandId",
                    "Not Found Brand Id! :) ");
            }

            var brandResponse = new DeleteBrandResponse
            {
                
            };

            return brandResponse;
        }
    }

}





