using System.Web.Mvc;

namespace ProyectoOL.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult PageNotFound()
        {
            return View();
        }
    }
}