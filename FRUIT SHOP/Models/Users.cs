using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FRUIT_SHOP.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int Id { get; set; }
        
        [Required,MaxLength(50,ErrorMessage ="Max Lenght 50 char")]
        public string Name { get; set; }

        [Required, DataType(DataType.EmailAddress,ErrorMessage = "Email Is Invalid")]

        public string Email { get; set; }

        [Required,MinLength(11,ErrorMessage ="Invaild Phone Number"),MaxLength(11, ErrorMessage = "Invaild Phone Number")]
        public string PhoneNumber { get; set; }

        [Required,MinLength(6,ErrorMessage ="Min Length 6 char")]
        public string Password { get; set; }
        [NotMapped,Compare("Password",ErrorMessage ="Password Not Matched")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Set that Is Admin from data-base ==> true or false 
        /// in developermnt we will bulit admindashBoard to control this ==>
        /// </summary>
        public bool IsAdmin { get; set; }
       

    }
}
