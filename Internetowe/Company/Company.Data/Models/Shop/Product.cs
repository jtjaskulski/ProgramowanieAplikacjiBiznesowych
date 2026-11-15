using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Data.Models.Shop
{

    public class Product
    {
        [Key]
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "Code of product is required")]
        public required string Code { get; set; }

        [Required(ErrorMessage = "Name of product is required")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Price of product is required")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        //[Required(ErrorMessage = "Photo of product is required")]
        [Display(Name = "Select your photo")]
        public required string FotoURL { get; set; }

        [Display(Name = "Description")]
        public required string Description { get; set; }
        
        [Display(Name = "Is that product discounted?")]
        public bool IsDiscount { get; set; }

        [Display(Name = "Category of the product")]
        public int IdCategory { get; set; }

        [Display(Name = "Category of the product")]
        [ForeignKey("IdCategory")]
        public virtual Category? Category { get; set; }
    }
}