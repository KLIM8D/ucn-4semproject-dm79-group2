using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Resources;

namespace BusinessLogic.Resources
{
    public class AuthorizeService
    {
        private SecurityGroupRepository _securityGroupRepo;
        private UserRepository _userRepo;

        public AuthorizeService()
        {
            _securityGroupRepo = new SecurityGroupRepository();
            _userRepo = new UserRepository();
        }

        public bool IsUserInRole(string roleName, string userName)
        {
            var role =_securityGroupRepo.GetGroupByTitle(roleName);
            if (role != null)
            {
                var user = _userRepo.GetCredentials(userName);
                if (user != null)
                    return role.sec_gro_id == user.sec_gro_id;
            }

            return false;
        }
    }
}
