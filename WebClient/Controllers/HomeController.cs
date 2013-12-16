using System.Web.Mvc;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Request.IsAuthenticated)
                return View("../Account/Index");

            return View();
        }
    }
}