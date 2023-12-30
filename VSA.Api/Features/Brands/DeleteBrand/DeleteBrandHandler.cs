using MediatR;
using VSA.Api.Infrastructure.Database;
using VSA.Api.Shared;

namespace VSA.Api.Features.Brands.DeleteBrand
{
    public class DeleteBrandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandResponse>
    {
        private readonly AppDbContext _dbContext;

        private readonly Util _util;

        public DeleteBrandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public Task<DeleteBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var isTrue = _util.isBrandExist(request.Id);

            var BrandResponse = new DeleteBrandResponse
            {

            };

            if(isTrue)
            {
                _dbContext.Remove(request.Id);
                _dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new ErrorException(
                    "DeleteBrand.NotFoundBrandId",
                    "Not Found Brand Id! :) ");
            }

            


        }

        
    }

    
}

    


