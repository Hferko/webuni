using Microsoft.AspNetCore.Mvc;
using MVCWebHello.Models;
using System.Diagnostics;

namespace MVCWebHello.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            Beolvas file = new Beolvas();
            ViewData.Model = file.Nevek;
            ViewData.Model = file.Idok;
            ViewData.Model = file.Ipk;
            
            return View(file);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}