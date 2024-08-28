using Microsoft.AspNetCore.Mvc;

namespace Alikabook.Views.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
