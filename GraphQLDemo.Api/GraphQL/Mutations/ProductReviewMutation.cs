using GraphQLDemo.Api.Data.Repositories;
using GraphQLDemo.Api.Domain.Entities;
using GraphQLDemo.Api.GraphQL.Inputs;
using GraphQLDemo.Api.Products.Commands.AddProductReview;
using MediatR;

namespace GraphQLDemo.Api.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class ProductReviewMutation
    {
        public Task<ProductReview> AddReviewAsync(ProductReviewInput input,
            [Service] IMediator mediator)
        {
            return mediator.Send(new AddProductReviewCommand(
                input.ProductId,
                input.Title,
                input.Review
            ));
        }
    }
}
