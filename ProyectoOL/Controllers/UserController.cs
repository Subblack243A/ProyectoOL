using ProyectoOL.Dto;
using ProyectoOL.Permissions;
using ProyectoOL.Services;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoOL.Controllers
{
    [HandleError]
    public class UserController : Controller
    {
        private UserDto userLogin = new UserDto();

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
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            UserService userService = new UserService();
            UserDto userRegister = userService.CreateUser(user);
            if (userRegister.Id_Usuario != -1)
            {
                user = userService.CleanUser(user);
                return RedirectToAction("Index", "Home");
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
            FormsAuthentication.SetAuthCookie(userLogin.Nombre_Usuario, false);
            Session["User"] = userLogin;
            return View("Dashboard", userLogin);
        }

        [Authorize]
        [RolPermissions(true, false, false)]
        public ActionResult RegisterAdmin()
        {
            UserDto user = new UserDto(); 
            return View(user);
        }

        [HttpPost]
        [RolPermissions(true, false, false)]
        public ActionResult RegisterAdmin(UserDto user)
        {
            UserService userService = new UserService();
            UserDto userRegister = userService.CreateUser(user);
            if (userRegister.Id_Usuario != -1)
            {
                user = userService.CleanUser(user);
                return RedirectToAction("RegisterAdmin", "User");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}