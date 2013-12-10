using System.Web.Mvc;
using BusinessLogic.Resources;
using Repository.Models;
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
                var deposit = new vault_depositits()
                                           {
                                               usr_det_id = model.UserId,
                                               vau_dep_amount = model.Amount,
                                           };

                bool success = new DepositLogic().SaveDeposit(deposit);
                if (success)
                    return View("Index");
            }
            return View();
        }

    }
}