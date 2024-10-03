using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList20240926.Data.Models
{
    public class ProductNote
    {
        [Key]
        [Comment("ProductNote identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        [Comment("ProductNote content")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("Product identifier")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
