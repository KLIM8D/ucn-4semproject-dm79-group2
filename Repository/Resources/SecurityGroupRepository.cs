using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Resources
{
    public class SecurityGroupRepository
    {
        private RKConn db;

        public SecurityGroupRepository()
        {
            db = new RKConn();
        }

        public security_groups GetGroupByTitle(string title)
        {
            return db.security_groups.FirstOrDefault(x => x.sec_gro_title.Equals(title));
        }
    }
}
