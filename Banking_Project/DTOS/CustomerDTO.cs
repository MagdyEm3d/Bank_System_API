using Banking_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Banking_Project.DTOS
{
    public class CustomerDTO
    {

        [Required(ErrorMessage = "Please Enter Your Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress(ErrorMessage = "Email not include the stracture")]
        public string CustomerEmail { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Phone number must be 15 number only")]
        public string CustomerPhone { get; set; }
        [Required(ErrorMessage ="Please Enter Your CardNumber")]
        public int BankCardId { get; set; }
        
        
    }
}
