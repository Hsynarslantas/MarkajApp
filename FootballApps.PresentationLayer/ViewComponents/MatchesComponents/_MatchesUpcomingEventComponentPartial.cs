using FootballApps.DtoLayer.Dtos.MatchsDtos;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FootballApps.PresentationLayer.ViewComponents.MatchesComponents
{
    public class _MatchesUpcomingEventComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MatchesUpcomingEventComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public   async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7165/api/Matchs/GetUpcomingMatchEvent");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultsMatchDto>>(jsonData);
            return View(values);
        }
    }
}
