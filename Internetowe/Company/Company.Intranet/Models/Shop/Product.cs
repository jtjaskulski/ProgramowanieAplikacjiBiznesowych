using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Intranet.Models.Shop
{

    public class Product
    {
        [Key]
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "Code of product is required")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name of product is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price of product is required")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        //[Required(ErrorMessage = "Photo of product is required")]
        [Display(Name = "Select your photo")]
        public string FotoURL { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Category of the product")]
        public int IdCategory { get; set; }

        [Display(Name = "Category of the product")]
        [ForeignKey("IdCategory")]
        public virtual Category? Category { get; set; }
    }
}