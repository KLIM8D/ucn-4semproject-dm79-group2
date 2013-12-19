using System;
using System.Collections.Generic;
using System.Linq;
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
            var model = new DepositViewModel();
            var _userLogic = new UserLogic();
            model.Balance = _userLogic.GetBalanceByUserId(_userLogic.GetUserIdByUserName(HttpContext.User.Identity.Name)).ToString("N");
            return View(model);
        }

        [HttpPost]
        [AuthorizeUser(Role = "User")]
        public ActionResult DepositMoney(DepositViewModel model)
        {
            var _userLogic = new UserLogic();
            if (ModelState.IsValid)
            {
                
                var deposit = new vault_depositits()
                                           {
                                               usr_det_id = _userLogic.GetUserIdByUserName(HttpContext.User.Identity.Name),
                                               vau_dep_timestamp = DateTime.Now,
                                               vau_dep_amount = model.Amount,
                                           };

                bool success = new DepositLogic().SaveDeposit(deposit);
                if (success)
                {
                    model.Message = "Success!";
                }
                else
                {
                    model.Message = "Error!";
                }
            }
            ModelState.Clear();
            model.Balance = _userLogic.GetBalanceByUserId(_userLogic.GetUserIdByUserName(HttpContext.User.Identity.Name)).ToString("N");
            return View(model);
        }

    }
}