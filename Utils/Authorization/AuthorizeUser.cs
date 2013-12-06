﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Utils.Authorization
{
    class AuthorizeUser : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                // The user is not authenticated
                return false;
            }

            var user = httpContext.User;
            if (user.IsInRole("Admin"))
            {
                // Administrator => let him in
                return true;
            }

            var rd = httpContext.Request.RequestContext.RouteData;
            var id = rd.Values["id"] as string;
            if (string.IsNullOrEmpty(id))
            {
                // Now id was specified => we do not allow access
                return false;
            }

            return IsOwnerOfPost(user.Identity.Name, id);
        }

        private bool IsOwnerOfPost(string username, string postId)
        {
            // TODO: you know what to do here
            throw new NotImplementedException();
        }
    }
}
