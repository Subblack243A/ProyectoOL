using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoOL.Controllers
{
    public class LibrarianController : Controller
    {
        // GET: Librarian
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Books() 
        {
            return View();
        }
        public ActionResult People()
        {
            return View();
        }
    }
}