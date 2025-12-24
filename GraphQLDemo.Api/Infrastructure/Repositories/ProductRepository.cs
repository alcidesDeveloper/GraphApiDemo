using GraphQLDemo.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Api.Data.Repositories
{
    public class ProductRepository
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Product> Query()
       => _dbContext.Products.AsNoTracking();

        public async Task<Product> AddAsync(Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                return product;
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        public Task<bool> ExistsAsync(int productId)
        => _dbContext.Products.AnyAsync(p => p.Id == productId);
    }
}
