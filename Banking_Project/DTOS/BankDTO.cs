using System.ComponentModel.DataAnnotations;

namespace Banking_Project.DTOS
{
    public class BankDTO
    {

        [Required(ErrorMessage = "Please Enter Your Card Number")]
        [MaxLength(16, ErrorMessage = "Card Number must be 16 numbers only")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Expire Date")]
        public DateTime Expiredate { get; set; }
    }
}
