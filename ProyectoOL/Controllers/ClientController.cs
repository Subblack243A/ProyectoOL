using ProyectoOL.Dtos;
using ProyectoOL.Services;
using System.Web.Mvc;

namespace ProyectoOL.Controllers
{
    [HandleError]
    public class ClientController : Controller
    {
    [Authorize]
        public ActionResult Index()
        {
            BooksService booksService = new BooksService();
            return View(booksService.GetAllBooks());
        }
    }
}