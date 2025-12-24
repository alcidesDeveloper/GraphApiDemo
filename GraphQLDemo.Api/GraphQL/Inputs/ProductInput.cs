using GraphQLDemo.Api.Domain.Enums;

namespace GraphQLDemo.Api.GraphQL.Inputs
{
    public record ProductInput
     (string Name,
     decimal Price,
     ProductType Type,
     string Desc,
     int Stock,
     int Rating,
     IEnumerable<CreateProductReviewInput> Reviews);
}
