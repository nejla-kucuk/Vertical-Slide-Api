using MediatR;
using VSA.Api.Entities;
using VSA.Api.Infrastructure.Database;

namespace VSA.Api.Shared
{
    public class Util
    {
        private readonly AppDbContext _dbContext;

        public Util(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> BrandIdExist(Guid Id)
        {
            var brand = await _dbContext.Brands.FindAsync(Id);
            return brand != null;
        }

    }
}
