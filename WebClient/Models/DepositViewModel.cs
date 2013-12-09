using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class DepositViewModel
    {
        [Required(ErrorMessage = "Skal udfyldes")]
        [DataType(DataType.Text)]
        [DisplayName("Beløb")]
        public string Amount { get; set; }
        [Required(ErrorMessage = "Skal udfyldes")] 
        [DataType(DataType.CreditCard)] 
        [DisplayName("Kortnummer")]
        public string CreditCardNumber { get; set; }
    }
}