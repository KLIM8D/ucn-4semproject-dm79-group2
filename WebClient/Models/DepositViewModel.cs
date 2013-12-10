using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class DepositViewModel
    {

        [Required(ErrorMessage = "Skal udfyldes")]
        [DataType(DataType.Currency)]
        [DisplayName("Beløb")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")] 
        [DataType(DataType.CreditCard)] 
        [DisplayName("Kortnummer")]
        public string CreditCardNumber { get; set; }

        public int UserId { get; set; }
        
    }
}