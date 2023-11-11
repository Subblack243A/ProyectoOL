using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoOL.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            Session["User"] = null;
            return View();
        }

        public ActionResult Digital()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}