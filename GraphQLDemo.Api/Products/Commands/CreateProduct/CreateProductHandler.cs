using GraphQLDemo.Api.Data.Repositories;
using GraphQLDemo.Api.Domain.Entities;
using MediatR;

namespace GraphQLDemo.Api.Products.Commands.CreateProduct
{
    public class CreateProductHandler
    : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly ProductRepository _products;

        public CreateProductHandler(ProductRepository products)
        {
            _products = products;
        }

        public async Task<Product> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Type = request.Type,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
                ProductReviews = request.Reviews?
                    .Select(r => new ProductReview
                    {
                        Title = r.Title,
                        Review = r.Review
                    })
                    .ToList() ?? new()
            };

            return await _products.AddAsync(product);
        }
    }
}
