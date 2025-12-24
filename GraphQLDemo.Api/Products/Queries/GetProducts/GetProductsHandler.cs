using GraphQLDemo.Api.Data.Repositories;
using GraphQLDemo.Api.Domain.Entities;
using MediatR;

namespace GraphQLDemo.Api.Products.Queries.GetProducts
{
    public class GetProductsHandler
    : IRequestHandler<GetProductsQuery, IQueryable<Product>>
    {
        private readonly ProductRepository _products;

        public GetProductsHandler(ProductRepository products)
        {
            _products = products;
        }

        public Task<IQueryable<Product>> Handle(
            GetProductsQuery request,
            CancellationToken cancellationToken)
            => Task.FromResult(_products.Query());
    }
}
