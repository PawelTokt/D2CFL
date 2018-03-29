using Microsoft.AspNetCore.Mvc;

namespace D2CFL.WebSite.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}