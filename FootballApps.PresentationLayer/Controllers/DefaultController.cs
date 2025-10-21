using Microsoft.AspNetCore.Mvc;

namespace FootballApps.PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
