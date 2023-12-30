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

           
                var brandExists = _util.BrandIdExist(request.Id);

                var BrandResponse = new DeleteBrandResponse
                {
                    
                };

                if (brandExists)
                {
                    var brand =  _dbContext.Brands.FindAsync(request.Id);
                    _dbContext.Brands.Remove(brand);
                    _dbContext.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new ErrorException(
                        "DeleteBrand.NotFoundBrandId",
                        "Not Found Brand Id! :) ");
                }

                // ... BrandResponse'i kullanarak işlemleri tamamlayabilirsiniz

                return BrandResponse;
            }



            aw_util.BrandIdExist(request.Id);

            var BrandResponse = new DeleteBrandResponse
            {
                
            };

            if(BrandId)
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

    


