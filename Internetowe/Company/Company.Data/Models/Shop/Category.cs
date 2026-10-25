using System.ComponentModel.DataAnnotations;

namespace Company.Data.Models.Shop
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }

        [Required(ErrorMessage = "Name of category is required")]
        [MaxLength(30, ErrorMessage = "Name of category should have max 30 characters")]
        public string Name { get; set; }

        public string? Description { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
