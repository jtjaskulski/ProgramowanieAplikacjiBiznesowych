using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Data.Models.CMS
{
    public class Page
    {
        /// <summary>
        /// Primary key of page.
        /// </summary>
        [Key]
        public int IdPage { get; set; }

        /// <summary>
        /// Gets or sets the title link associated with the entity. This property is required and must not exceed 10
        /// characters in length.
        /// </summary>
        /// <remarks>Use this property to specify a short, descriptive title link. The value must be
        /// provided and should not be longer than 10 characters to meet validation requirements.</remarks>
        [Required(ErrorMessage = "Title link is required")]
        [MaxLength(10, ErrorMessage = "Title link should have only 10 characters.")]
        [Display(Name = "Title link")]
        public string LinkTitle { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(30, ErrorMessage = "Title should have only 30 characters.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Content")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }

        [Display(Name = "Order of display")]
        [Required(ErrorMessage = "Order of display is required")]
        public int DisplayOrder { get; set; }
    }
}
