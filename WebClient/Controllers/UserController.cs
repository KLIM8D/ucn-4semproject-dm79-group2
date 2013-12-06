using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Resources;
using Repository.Models;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(UserViewModel model)
        {
            long mSsn;
            if (ModelState.IsValid)
            {
                model.Ssn = model.Ssn.Replace("-", "");
                model.Ssn = model.Ssn.Replace(".", "");
                if (long.TryParse(model.Ssn, out mSsn))
                {
                    User user = new User
                                {
                                    fname = model.FirstName,
                                    lname = model.SurName,
                                    created_timestamp = DateTime.Now,
                                    email = model.EMail,
                                    is_active = true,
                                    passwd = model.Password,
                                    phoneno = model.PhoneNo,
                                    sec_group = "User",
                                    ssn = mSsn
                                };

                    bool success = new UserLogic().SaveUser(user);
                    if (success)
                        return View("Index");
                }
            }

            return View(model);
        }
    }
}
