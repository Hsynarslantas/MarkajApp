
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.PresentationLayer.Controllers
{
    public class BlogController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            ViewBag.BlogId = id;
            return View();
        }
    }
}
