using GraphQLDemo.Api.Domain.Entities;
using GraphQLDemo.Api.GraphQL.DataLoaders;

namespace GraphQLDemo.Api.GraphQL.Resolvers
{
    [ExtendObjectType(typeof(Product))]
    public class ProductResolvers
    {
        public async Task<IEnumerable<ProductReview>> Reviews(
            [Parent] Product product,
            ProductReviewsByProductIdDataLoader dataLoader,
            CancellationToken cancellationToken)
        {
            return await dataLoader.LoadAsync(product.Id, cancellationToken);
        }
    }
}
