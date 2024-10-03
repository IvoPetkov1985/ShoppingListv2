using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList20240926.Data.Models
{
    public class Product
    {
        [Key]
        [Comment("Product identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Comment("Product name")]
        public string Name { get; set; } = string.Empty;

        public IList<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();
    }
}
