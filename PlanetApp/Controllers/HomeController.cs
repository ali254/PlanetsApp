using Logic.Planet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlanetService planetService;
        public HomeController(IPlanetService planetService)
        {
            this.planetService = planetService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
