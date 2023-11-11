using ProyectoOL.Permissions;
using ProyectoOL.Services;
using System.Web.Mvc;

namespace ProyectoOL.Controllers
{
    [HandleError]
    public class ClientController : Controller
    {
        [Authorize]
        [RolPermissions(true, true, true)]
        public ActionResult Index()
        {
            BooksService booksService = new BooksService();
            return View(booksService.GetAllBooks());
        }
    }
}