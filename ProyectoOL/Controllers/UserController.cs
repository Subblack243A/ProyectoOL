using ProyectoOL.Dto;
using ProyectoOL.Services;
using ProyectoOL.Utilities;
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
            EmailUtility email = new EmailUtility();
            UserService userService = new UserService();
            UserDto userRegister = userService.CreateUser(user);
            if (userRegister.Id_Usuario != -1)
            {
                string destino = userRegister.Correo_Electronico;
                string asunto = "Creación de usuario";
                string mensaje = "Se ha creado correctamente el usuario";
                email.SendEmail(destino, asunto, mensaje, false);
                user = userService.CleanUser(user);
                return View("InicioSesion");
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
            EmailUtility email = new EmailUtility();
            string destino = userLogin.Correo_Electronico;
            string asunto = "Ingreso a Open Library";
            string mensaje = "Se ha ingresado a la aplicación";
            email.SendEmail(destino, asunto, mensaje);
            return View("Dashboard", userLogin);
        }
    }
}