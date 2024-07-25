using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EcosistemasMarinos.MVC.Models;

namespace LogicaNegocio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() {
            if (User.Identity != null && User.Identity.IsAuthenticated) {
                ViewBag.MensajeBienvenida = $"¡Bienvenido! Nuestros admins confiaron en ud. para modificar el contenido del sitio.";
            } else {
                ViewBag.MensajeBienvenida = "Para modificar el contenido, debe iniciar sesión.";
            } 
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}