using System.Web.Mvc;
using BusinessLogic.Resources;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class DepositController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DepositMoney()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DepositMoney(DepositViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = model.ConvertToBusinessModel();

                bool success = new UserLogic().SaveUser(user);
                if (success)
                    return View("Index");
            }

            return View(model);
        }
    }
}
