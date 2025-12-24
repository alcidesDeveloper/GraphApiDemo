using GraphQLDemo.Api.Domain.Entities;
using GraphQLDemo.Api.Domain.Enums;
using MediatR;

namespace GraphQLDemo.Api.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
    string Name,
    ProductType Type,
    string Description,
    decimal Price,
    int Stock,
    List<CreateProductReviewDto>? Reviews
) : IRequest<Product>;
}
