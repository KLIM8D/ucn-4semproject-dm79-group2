using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Resources;
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
            if (ModelState.IsValid)
            {
                //User user = new User
                //                              {
                //                                  UserAddress = new UserAddress()
                //                                                {
                //                                                    Street = model.Street,
                //                                                    Zipcode = new Zipcode()
                //                                                              {
                //                                                                  City = model.City,
                //                                                                  Code = model.ZipCode
                //                                                              }
                //                                                },
                //                                  UserDetails = new UserDetails()
                //                                                {
                //                                                    EMail = model.EMail,
                //                                                    FirstName = model.FirstName,
                //                                                    SurName = model.SurName,
                //                                                    PhoneNo = model.PhoneNo,
                //                                                    Ssn = model.Ssn
                //                                                },
                //                                  SecurityCredentials = new SecurityCredentials()
                //                                                        {
                //                                                            Password = model.Password
                //                                                        }

                //                              };

                var user = new Object();

                bool success = new UserLogic().SaveUser(user);
                if (success)
                    return View("Index");
            }

            return View(model);
        }
    }
}
