using FootballApps.DtoLayer.Dtos.CommentDtos;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FootballApps.DtoLayer.Dtos.ContactCommentDtos;

namespace FootballApps.PresentationLayer.ViewComponents.ContactComponents
{
    public class _ContactCreateCommentComponentPartial:ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
           return View();
        }
    }
}
