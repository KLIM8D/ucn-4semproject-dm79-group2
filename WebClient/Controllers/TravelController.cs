using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository.Resources;
using Utils.Authorization;

namespace WebClient.Controllers
{
    public class TravelController : Controller
    {
        [AuthorizeUser(Role = "User")]
        public ActionResult ViewTravelDetails()
        {
            UserRepository _userRepo = new UserRepository();
            int id = _userRepo.GetUserId(HttpContext.User.Identity.Name);
            var travelRepo = new RegisterRepository();
            var model = travelRepo.GetRegisterTravelByUserId(id).ToList();
            return View(model);
        }
    }
}
