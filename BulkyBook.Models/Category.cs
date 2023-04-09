using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        [Range(0, 100, ErrorMessage = "Display Order can only be 0 up to 100.")]
        public int DisplayOrder { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
