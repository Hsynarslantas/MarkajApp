using System.Threading.Tasks;
using FootballApps.DtoLayer.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FootballApps.PresentationLayer.ViewComponents.BlogComponents
{

    public class _BlogDetailComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7165/api/Blogs/{id}");
            var blog = JsonConvert.DeserializeObject<ResultBlogDto>(await response.Content.ReadAsStringAsync());
            return View(blog);
        }
    }
}
