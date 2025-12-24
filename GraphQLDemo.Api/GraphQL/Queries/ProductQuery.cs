using GraphQLDemo.Api.Data;
using GraphQLDemo.Api.Data.Repositories;
using GraphQLDemo.Api.Domain.Entities;
using GraphQLDemo.Api.Products.Queries.GetProducts;
using MediatR;

namespace GraphQLDemo.Api.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class ProductQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Product>> GetProducts([Service] IMediator mediator) =>
           await mediator.Send(new GetProductsQuery());
    }
}
