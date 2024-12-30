using System.ComponentModel.DataAnnotations;

namespace Banking_Project.Models
{
    public class Transactionn
    {
        [Key]
        public int TransactionId { get; set; }
        [Required(ErrorMessage ="Please Enter Your Amount")]
        public int amount { get; set; }
        [Required(ErrorMessage ="Please Enter Your Date")]
        public DateTime date { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
