using GraphQLDemo.Api.Data.Repositories;
using GraphQLDemo.Api.Domain.Entities;
using GraphQLDemo.Api.GraphQL.Inputs;
using GraphQLDemo.Api.Products.Commands.CreateProduct;
using MediatR;

namespace GraphQLDemo.Api.GraphQL.Mutations
{
    [ExtendObjectType("Mutation")]
    public class ProductMutation
    {
        public Task<Product> AddProductAsync(
            ProductInput input,
             [Service] IMediator mediator)
        {
            var result = mediator.Send(new CreateProductCommand(
            input.Name,
            input.Type,
            input.Desc,
            input.Price,
            input.Stock,
            input.Reviews?.Select(r =>
                new CreateProductReviewDto(r.Title, r.Review)).ToList()
        ));

            return result;
        }
        
    }
}
