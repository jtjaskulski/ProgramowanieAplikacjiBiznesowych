using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Data.Models.CMS
{
    public class News
    {

        [Key]
        public int IdNews { get; set; }

        [Required(ErrorMessage = "Title link is required")]
        [MaxLength(30, ErrorMessage = "Title link should have only 30 characters.")]
        [Display(Name = "Title link")]
        public required string LinkTitle { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(30, ErrorMessage = "Title should have only 30 characters.")]
        [Display(Name = "Title")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
        [Display(Name = "Content")]
        [Column(TypeName = "nvarchar(MAX)")]
        public required string Content { get; set; }

        [Display(Name = "Order of display")]
        [Required(ErrorMessage = "Order of display is required")]
        public int DisplayOrder { get; set; }
    }
}
