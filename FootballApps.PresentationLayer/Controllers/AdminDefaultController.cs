using Microsoft.AspNetCore.Mvc;

namespace FootballApps.PresentationLayer.Controllers
{
    public class AdminDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
