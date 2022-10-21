using REST_API_.Net_Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace REST_API_.Net_Core.Models
{
    public class ProductsDto
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "The Product Name is required")]
        [MaxLength(50, ErrorMessage = "The Product Name shouldn't have more than 50 characters")]
        public string ProdName { get; set; }
        [Required(ErrorMessage = "The Price Name is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The Quantity Name is required")]
        public decimal Quantity { get; set; }
        [Required(ErrorMessage = "The ImgURL Name is required")]
        [MaxLength(100, ErrorMessage = "The ImgURL shouldn't have more than 100 characters")]
        public string ImgURL { get; set; }
        [Required(ErrorMessage = "The Cateogry Name is required")]
        public Guid CateogryID { get; set; }
    }
}
