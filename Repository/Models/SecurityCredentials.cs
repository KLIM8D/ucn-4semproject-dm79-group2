using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class SecurityCredentials
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public SecurityGroup Group { get; set; }
        public bool Active { get; set; }
    }
}
