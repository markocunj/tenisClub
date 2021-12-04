using Microsoft.AspNetCore.Mvc;

namespace TC.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
