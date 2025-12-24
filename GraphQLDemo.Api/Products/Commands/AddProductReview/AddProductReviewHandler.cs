using GraphQLDemo.Api.Data.Repositories;
using GraphQLDemo.Api.Domain.Entities;
using MediatR;

namespace GraphQLDemo.Api.Products.Commands.AddProductReview
{
    public class AddProductReviewHandler
    : IRequestHandler<AddProductReviewCommand, ProductReview>
    {
        private readonly ProductRepository _products;
        private readonly ProductReviewRepository _reviews;

        public AddProductReviewHandler(
            ProductRepository products,
            ProductReviewRepository reviews)
        {
            _products = products;
            _reviews = reviews;
        }

        public async Task<ProductReview> Handle(
            AddProductReviewCommand request,
            CancellationToken cancellationToken)
        {
            if (!await _products.ExistsAsync(request.ProductId))
                throw new GraphQLException("Product not found");

            var review = new ProductReview
            {
                ProductId = request.ProductId,
                Title = request.Title,
                Review = request.Review
            };

            return await _reviews.AddAsync(review);
        }
    }
}
