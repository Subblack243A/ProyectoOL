﻿using System.Web.Mvc;

namespace ProyectoOL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Digital()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}