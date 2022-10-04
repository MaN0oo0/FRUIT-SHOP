using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRUIT_SHOP.Models
{
    public class OurFruit
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(25)]
        public string Titel { get; set; }
        [Required]
        public float Price { get; set; }
        [Required,MinLength(20,ErrorMessage ="Min Length 20 char")]
        public string Descreption { get; set; }
    }
}
