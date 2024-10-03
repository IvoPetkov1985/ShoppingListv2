using System.ComponentModel.DataAnnotations;

namespace ShoppingList20240926.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Display(Name = "Product name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Field {0} must be between {2} and {1} characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
