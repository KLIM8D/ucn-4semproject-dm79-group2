using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Repository.Resources;

namespace Utils.Authorization
{
    public class AuthorizeUser : AuthorizeAttribute
    {
        // Custom property
        public string Role { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
                return false;

            if (!String.IsNullOrEmpty(this.Role))
                return true;

            return IsUserInRole(this.Role, httpContext.User.Identity.Name);
        }

        public bool IsUserInRole(string roleName, string userName)
        {
            var securityGroupRepo = new SecurityGroupRepository();
            var userRepo = new UserRepository();
            var role = securityGroupRepo.GetGroupByTitle(roleName);
            if (role != null)
            {
                var user = userRepo.GetCredentials(userName);
                if (user != null)
                    return role.sec_gro_id == user.sec_gro_id;
            }

            return false;
        }
    }
}
