using Banking_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Banking_Project.DTOS
{
    public class AccountDTO
    {

        [Required(ErrorMessage = "Please Enter Your AccountNumber")]
        [MaxLength(20, ErrorMessage = "AccountNumber must be 20 number only")]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Your Balance")]
        public int balance { get; set; }
        [Required(ErrorMessage = "Please Enter Your CustomerId")]
        public int CustomerId { get; set; }
        
        
    }
}
