using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public UserAddress Address { get; set; }
        public SecurityCredentials Credentials { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Ssn { get; set; }
        public int PhoneNo { get; set; }
        public string EMail { get; set; }
        public bool Active { get; set; }
    }
}
