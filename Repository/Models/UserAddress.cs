using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class UserAddress
    {
        public int Id { get; set; }
        public Zipcode Zipcode { get; set; }
        public string Street { get; set; }
    }
}
