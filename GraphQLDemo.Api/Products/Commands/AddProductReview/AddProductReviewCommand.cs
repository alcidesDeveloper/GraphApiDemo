using GraphQLDemo.Api.Domain.Entities;
using MediatR;

namespace GraphQLDemo.Api.Products.Commands.AddProductReview
{
    public record AddProductReviewCommand(
    int ProductId,
    string Title,
    string? Review
) : IRequest<ProductReview>;
}
