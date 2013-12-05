﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class UserViewModel
    {
        //UserDetails
        [Required(ErrorMessage = "Skal udfyldes")]
        [DataType(DataType.Text)]
        [DisplayName("Fornavn")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Skal udfyldes")]
        [DataType(DataType.Text)]
        [DisplayName("Efternavn")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "Skal udfyldes")]
        [DataType(DataType.Text)]
        [DisplayName("CPR Nr.")]
        public string Ssn { get; set; }
        [Required(ErrorMessage = "Skal udfyldes")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Tlf. Nr.")]
        public int PhoneNo { get; set; }
        [Required(ErrorMessage = "Skal udfyldes")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail")]
        public string EMail { get; set; }

        //UserAddr
        [Required(ErrorMessage = "Skal udfyldes")]
        [DataType(DataType.Text)]
        [DisplayName("Adresse")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Skal udfyldes")]
        [DataType(DataType.PostalCode)]
        [DisplayName("Post Nr.")]
        public int ZipCode { get; set; }
        [Required(ErrorMessage = "Skal udfyldes")]
        [DataType(DataType.Text)]
        [DisplayName("By")]
        public string City { get; set; }

        //SecurityCred
        [Required(ErrorMessage = "Skal udfyldes")]
        [DataType(DataType.Text)]
        [DisplayName("Brugernavn")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Skal udfyldes")]
        [DataType(DataType.Password)]
        [DisplayName("Kodeord")]
        public string Password { get; set; }
    }
}