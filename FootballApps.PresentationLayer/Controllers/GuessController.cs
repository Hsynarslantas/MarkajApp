using FootballApps.PresentationLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.PresentationLayer.Controllers
{
    public class GuessController : Controller
    {
        private readonly AIService _chatService = new AIService();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Ask(string message)
        {
            var reply = await _chatService.GetChatReplyAsync(message);
            ViewBag.BotReply = reply;
            ViewBag.UserMessage = message;
            return View("Index");
        }
    }
}
