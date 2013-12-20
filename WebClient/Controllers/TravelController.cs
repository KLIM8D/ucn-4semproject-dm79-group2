using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Resources;
using Repository.Resources;
using Utils.Authorization;

namespace WebClient.Controllers
{
    public class TravelController : Controller
    {
        [AuthorizeUser(Role = "User")]
        public ActionResult ViewTravelDetails()
        {
            int id = new UserRepository().GetUserId(HttpContext.User.Identity.Name);
            var model = new RegisterLogic().GetAllTravelsByUserId(id);
            //var fareCollection = new FareCollectionLogic().GetAllFaresByUserId(id);


            return View(model);
        }
    }
}
