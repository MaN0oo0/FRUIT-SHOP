using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRUIT_SHOP.Models
{
    public class BuyingCarts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Count { get; set; }
        public float TotalPrice { get; set; }
        [ForeignKey("UserId")]
        public Users users { get; set; }
        public int UserId { get; set; }
    }
}
