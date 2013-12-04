using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class SecurityGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
    }
}
