using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GraphQLDemo.Api.Domain.Enums;

namespace GraphQLDemo.Api.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(100), Required]
        public string Name { get; set; } = default!;
        public ProductType Type { get; set; }
        [Required]
        public string Description { get; set; } = default!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Rating { get; set; }
        public DateTimeOffset IntroducedAt { get; set; }

        [StringLength(100)]
        public string PhotoFileName { get; set; } = default!;

        public List<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
    }
}
