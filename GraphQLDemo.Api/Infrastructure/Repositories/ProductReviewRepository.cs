using GraphQLDemo.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Api.Data.Repositories
{
    public class ProductReviewRepository
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductReviewRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductReview> AddAsync(ProductReview review)
        {
            try
            {
                _dbContext.ProductReviews.Add(review);
                await _dbContext.SaveChangesAsync();
                return review;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<ILookup<int, ProductReview>> GetByProductIdsAsync(
        IReadOnlyList<int> productIds,
        CancellationToken cancellationToken)
        {
            var reviews = await _dbContext.ProductReviews
                .Where(r => productIds.Contains(r.ProductId))
                .ToListAsync(cancellationToken);

            return reviews.ToLookup(r => r.ProductId);
        }
    }
}
