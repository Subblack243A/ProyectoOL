using ProyectoOL.Dtos;
using ProyectoOL.Permissions;
using ProyectoOL.Services;
using System.Web.Mvc;

namespace ProyectoOL.Controllers
{
    [HandleError]
    public class LibrarianController : Controller
    {

        //GET: Books
        [Authorize]
        [RolPermissions(true, false, true)]
        public ActionResult Books() 
        {
            return View();
        }

        //POST: Books
        [HttpPost]
        [Authorize]
        [RolPermissions(true, false, true)]
        public ActionResult Books(BookDto book)
        {
            BookDto bookDto = new BookDto();    
            BooksService bookS = new BooksService();
            bookDto = bookS.CreateBook(book);
            if(bookDto.Indice == 1) 
            {
                return RedirectToAction("Books", "Librarian");
            }
            else
            {
                return View();
            }
            
        }
    }
}