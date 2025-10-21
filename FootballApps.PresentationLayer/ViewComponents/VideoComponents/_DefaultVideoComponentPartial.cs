using FootballApps.DtoLayer.Dtos.MatchsDtos;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using FootballApps.DtoLayer.Dtos.VideoDtos;

namespace FootballApps.PresentationLayer.ViewComponents.VideoComponents
{
    public class _DefaultVideoComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultVideoComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7165/api/Videos");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultVideoDto>>(jsonData);
            return View(values);
        }
    }
}
