using System;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BusinessLogic.Resources;
using Repository.Models;
using Repository.Resources;
using Utils.Authorization;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class DepositController : Controller
    {
        [AuthorizeUser(Role = "User")]
        public ActionResult DepositMoney()
        {
            return View();
        }

        [HttpPost]
        [AuthorizeUser(Role = "User")]
        public ActionResult DepositMoney(DepositViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserRepository _userRepo = new UserRepository();
                var deposit = new vault_depositits()
                                           {
                                               usr_det_id = _userRepo.GetUserId(HttpContext.User.Identity.Name),
                                               vau_dep_timestamp = DateTime.Now,
                                               vau_dep_amount = model.Amount,
                                           };

                bool success = new DepositLogic().SaveDeposit(deposit);
                if (success)
                {
                    model.Message = "Success!";
                    return View(model);
                }
            }
            model.Message = "Error!";
            return View();
        }

    }
}