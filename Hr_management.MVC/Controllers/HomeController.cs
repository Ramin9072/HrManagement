using Microsoft.AspNetCore.Mvc;

namespace Hr_management.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
