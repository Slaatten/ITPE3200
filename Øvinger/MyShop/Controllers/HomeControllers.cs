using Microsoft.AspNetCore.Mvc;            // MVC-typer (Controller, IActionResult)

namespace MyShop.Controllers                // Navnerom for controllere i prosjektet
{
    public class HomeController : Controller // Controller som håndterer /Home/*-ruter
    {
        // GET: /Home/Index   (og også / hvis du bruker MapDefaultControllerRoute)
        public IActionResult Index()         // Action som returnerer forsiden (Index.cshtml)
        {
            return View();                   // Render View() -> Views/Home/Index.cshtml
        }
    }
}
