using ProyectoOL.Models;
using ProyectoOL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoOL.Controllers
{
    public class UserController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        //GET: Register
        public ActionResult Register()
        {
            UserModel user = new UserModel();
            return View(user);
        }

        //POST: Register
        [HttpPost]
        public ActionResult Register(UserModel user)
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
    }
}