using Microsoft.AspNetCore.Mvc;
using MVCWebHello.Models;

namespace MVCWebHello.Controllers
{
    public class EmberController : Controller
    {       
        public string? IpCim { get; private set; }
        public string? Belepve { get; private set; }

        [HttpGet]
        public IActionResult Index()
        {
            Ember emb = new Ember();
            emb.Nev = "Senki";
            emb.Szul = 0;            
            return View(emb);
        }
        
        public Task<IActionResult> Sikeres(Ember eee)
        {
            HttpContext.Response.Cookies.Append("userNev", eee?.Nev);
            string? v = HttpContext.Request.Cookies["userNev"];
            eee.Belepve = v;
            return Sikeres(eee);
        }
        
        [HttpPost]
        
        public async Task<IActionResult> Sikeres(Ember eee, string Belepve)        
        {
            IpCim = HttpContext.Connection.RemoteIpAddress?.ToString();

            HttpContext.Response.Cookies.Append("userNev", eee?.Nev);
            string? v = HttpContext.Request.Cookies["userNev"];
            eee.Belepve = v;
            _ = HttpContext.Request.Cookies["userNev"];
            return View(eee);
        }
       
    }
}
