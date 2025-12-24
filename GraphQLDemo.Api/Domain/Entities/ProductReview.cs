using System.ComponentModel.DataAnnotations;

namespace GraphQLDemo.Api.Domain.Entities
{
    public class ProductReview
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;

        [StringLength(200), Required]
        public string Title { get; set; } = default!;
        public string Review { get; set; } = default!;
    }
}
