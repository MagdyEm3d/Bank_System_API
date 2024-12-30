using System.ComponentModel.DataAnnotations;

namespace Banking_Project.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required(ErrorMessage ="Please Enter Your AccountNumber")]
        [MaxLength(20,ErrorMessage ="AccountNumber must be 20 number only")]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Your AccountNumber")]
        public int balance { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Transactionn> Transactions { get; set; }
    }
}
