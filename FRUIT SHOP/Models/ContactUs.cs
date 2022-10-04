using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRUIT_SHOP.Models
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        [MinLength(10,ErrorMessage ="Min letter is 10 word")]
        public string Message { get; set; }

        [ForeignKey("UserId")]
        public Users? user { get; set; }
        public int UserId { get; set; }
    }
}
