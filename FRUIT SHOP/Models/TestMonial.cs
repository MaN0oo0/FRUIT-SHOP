using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRUIT_SHOP.Models
{
    public class TestMonial
    {
        [Key]
        public int Id { get; set; }
        [MinLength(10,ErrorMessage ="Min Length 10 char")]
        public string Message { get; set; }
        [ForeignKey("UserId")]
        public Users? user { get; set; }
        public int UserId { get; set; }
    }
}
