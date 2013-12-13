using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Resources;
using Repository.Models;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class UserController : Controller
    {
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
                                    uname = model.UserName,
                                    email = model.EMail,
                                    is_active = true,
                                    passwd = model.Password,
                                    phoneno = model.PhoneNo,
                                    sec_group = "User",
                                    ssn = Encoding.UTF8.GetBytes(mSsn.ToString()),
                                    zipcode = model.ZipCode,
                                    street = model.Street
                                };

                    bool success = new UserLogic().SaveUser(user);
                    if (success)
                        return View("../Home/Index");
                }
            }

            return View(model);
        }

        public JsonResult GetCityByZipCode(int zipCode)
        {
            var record = new UserLogic().GetCityByZipCode(zipCode);
            var result = new
                         {
                             CityName = record.geo_zip_city ?? "Ikke korrekt postnummer"
                         };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
