using GraphQLDemo.Api.Domain.Entities;
using MediatR;

namespace GraphQLDemo.Api.Products.Queries.GetProducts
{
    public record GetProductsQuery : IRequest<IQueryable<Product>>;
}
