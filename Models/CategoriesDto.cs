using System.ComponentModel.DataAnnotations;

namespace REST_API_.Net_Core.Models
{
    public class CategoriesDto
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "The Category Name is required")]
        [MaxLength(50, ErrorMessage = "The Category Name shouldn't have more than 50 characters")]
        public string CatName { get; set; }
    }
}
