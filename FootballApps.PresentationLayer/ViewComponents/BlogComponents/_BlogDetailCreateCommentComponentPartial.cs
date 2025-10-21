using FootballApps.DtoLayer.Dtos.CommentDtos;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.PresentationLayer.ViewComponents.BlogComponents
{
    public class _BlogDetailCreateCommentComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new CreateCommentDto());
        }
    }
}
