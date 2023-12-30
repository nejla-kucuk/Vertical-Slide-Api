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

        public bool isBrandExist(Guid id)
        {
           _dbContext.Brands.Any(b => b.Id == id);

        }
    }
}
