using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class User
    {
        public UserDetails UserDetails { get; set; }
        public UserAddress UserAddress { get; set; }
        public SecurityCredentials SecurityCredentials { get; set; }
    }
}
