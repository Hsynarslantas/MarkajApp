using FootballApps.DtoLayer.Dtos.TeamDtos;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using FootballApps.DtoLayer.Dtos.PlayerDtos;

namespace FootballApps.PresentationLayer.ViewComponents.AdminComponents
{
    public class _AdminMostGoalPlayerComponentPartial:ViewComponent
    {
        private  readonly IHttpClientFactory _httpClientFactory;

        public _AdminMostGoalPlayerComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7165/api/Players/GetMostGoal5Players");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultPlayerDto>>(jsonData);
            return View(values);
        }
    }
}
