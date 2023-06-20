using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace E_Coms_Razor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 50, ErrorMessage = "Order must be between 1 - 50")]
        public int DisplayOrder { get; set; }
    }
}
