using Banking_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Banking_Project.DTOS
{
    public class TrainsitionDTO
    {

        [Required(ErrorMessage = "Please Enter Your Amount")]
        public int amount { get; set; }
        [Required(ErrorMessage = "Please Enter Your Date")]
        public DateTime date { get; set; }
        public int AccountId { get; set; }

    }
}
