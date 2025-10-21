using Microsoft.AspNetCore.Mvc;

namespace FootballApps.PresentationLayer.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
