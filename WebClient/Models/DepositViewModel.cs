using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace WebClient.Models
{
    public class DepositViewModel
    {
        [Range(100, 1000, ErrorMessage = "Beløbet skal være mellem 100 og 1000 kr.")]
        [Required(ErrorMessage = "Skal udfyldes")]
        [DataType(DataType.Currency)]
        [DisplayName("Beløb")]
        public int Amount { get; set; }

        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$", ErrorMessage = "Ugyldigt Kreditkort nummer")]
        [Required(ErrorMessage = "Skal udfyldes")] 
        [DataType(DataType.CreditCard)] 
        [DisplayName("Kortnummer")]
        public string CreditCardNumber { get; set; }

        public int UserId { get; set; }

        public string Message { get; set; }

        [DisplayName("Saldo:")]
        public string Balance { get; set; }
    }
}