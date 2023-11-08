using ProyectoOL.Dtos;
using ProyectoOL.Services;
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

        //GET: Books
        public ActionResult Books() 
        {
            return View();
        }

        //POST: Books
        [HttpPost]
        public ActionResult Books(BookDto book)
        {
            BookDto bookDto = new BookDto();    
            BooksService bookS = new BooksService();
            bookDto = bookS.CreateBook(book);
            if(bookDto.Indice == 1) 
            {
                return RedirectToAction("Index", "Librarian");
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult People()
        {
            return View();
        }
    }
}