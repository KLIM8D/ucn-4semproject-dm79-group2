using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebClient.Models
{
    public class UserViewModel
    {
        //UserDetails
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        [DisplayName("Fornavn")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        [DisplayName("Efternavn")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        [DisplayName("CPR Nr.")]
        public string Ssn { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Indtast venligst et 8 cifret telefon nummer")]
        [DisplayName("Tlf. Nr.")]
        public int PhoneNo { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail")]
        public string EMail { get; set; }

        //UserAddr
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        [DisplayName("Adresse")]
        public string Street { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.PostalCode)]
        [DisplayName("Post Nr.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Indtast venligst et 4 cifret post nummer")]
        public int ZipCode { get; set; }
        [Required(ErrorMessage = "*")]
        public string City { get; set; }

        //SecurityCred
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        [DisplayName("Brugernavn")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [DisplayName("Kodeord")]
        public string Password { get; set; }
    }
}