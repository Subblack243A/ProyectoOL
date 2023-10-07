﻿using ProyectoOL.Models;
using ProyectoOL.Services;
using System.Web.Mvc;

namespace ProyectoOL.Controllers
{
    public class UserController : Controller
    {
        UserModel userLogin = new UserModel();
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        //GET: Register
        public ActionResult Registro()
        {
            UserModel user = new UserModel();
            return View(user);
        }

        //POST: Register
        [HttpPost]
        public ActionResult Registro(UserModel user)
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

        //GET:LOGIN
        public ActionResult InicioSesion()
        {
            UserModel user = new UserModel();
            return View(user);
        }
        //POST login
        [HttpPost]
        public ActionResult InicioSesion(UserModel usuario)
        {
            UserService usuarioService = new UserService();
            userLogin = usuarioService.InicioSesion(usuario);
            return View("Dashboard", userLogin);
        }
    }
}