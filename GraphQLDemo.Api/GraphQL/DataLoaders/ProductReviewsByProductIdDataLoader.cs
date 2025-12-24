using GraphQLDemo.Api.Data.Repositories;
using GraphQLDemo.Api.Domain.Entities;

namespace GraphQLDemo.Api.GraphQL.DataLoaders
{
    public class ProductReviewsByProductIdDataLoader : GroupedDataLoader<int, ProductReview>
    {
        private readonly ProductReviewRepository _repository;

        public ProductReviewsByProductIdDataLoader(
            ProductReviewRepository repository,
            IBatchScheduler batchScheduler)
            : base(batchScheduler, new DataLoaderOptions())
        {
            _repository = repository;
        }

        protected override Task<ILookup<int, ProductReview>> LoadGroupedBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            return _repository.GetByProductIdsAsync(keys, cancellationToken);
        }
    }
}
