﻿using System.Web.Mvc;

namespace WebIdeias.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ViewBag.Message - Home";

            return View();
        }
    }
}
