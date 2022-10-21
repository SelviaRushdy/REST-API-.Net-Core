using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_.Net_Core.Entities
{
    public class Products
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        [MaxLength(100)]
        public string ImgURL { get; set; }

        [ForeignKey("CateogryID")]
        public Category Category { get; set; }
        public Guid CateogryID { get; set; }


    }
}
