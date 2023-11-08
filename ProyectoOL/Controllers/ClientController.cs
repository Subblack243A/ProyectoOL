using ProyectoOL.Dtos;
using ProyectoOL.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProyectoOL.Controllers
{
    public class ClientController : Controller
    {
        public ActionResult Index()
        {
            BooksService booksService = new BooksService();
            return View(booksService.GetAllBooks());
        }

        public ActionResult DigitalLibrary()
        {
            return View();
        }
    }
}