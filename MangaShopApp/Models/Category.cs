using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MangaWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Range(0, 100, ErrorMessage = "This value is out of range!")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}