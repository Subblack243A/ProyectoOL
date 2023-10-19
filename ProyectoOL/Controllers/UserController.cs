using ProyectoOL.Models;
using ProyectoOL.Services;
using System.Web.Mvc;

namespace ProyectoOL.Controllers
{
    public class UserController : Controller
    {
        UserDto userLogin = new UserDto();

        //GET: Register
        public ActionResult Register()
        {
            UserDto user = new UserDto();
            return View(user);
        }

        //POST: Register
        [HttpPost]
        public ActionResult Register(UserDto user)
        {
            UserService userService = new UserService();
            bool result = userService.CreateUser(user);
            if (result)
            {
                return View("Index");
            }
            else
            {
                return View();
            }
        }

        //GET login
        public ActionResult InicioSesion()
        {
            UserDto user = new UserDto();
            return View(user);
        }
        //POST login
        [HttpPost]
        public ActionResult InicioSesion(UserDto usuario)
        {
            UserService usuarioService = new UserService();
            userLogin = usuarioService.InicioSesion(usuario);
            return View("Dashboard", userLogin);
        }
    }
}