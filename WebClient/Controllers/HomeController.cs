using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Resources;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Object();

                //bool success = new UserLogic().SaveUser(user);
                bool success = true;
                if (success)
                    return View("Index");
            }

            return View(model);
        }
    }
}