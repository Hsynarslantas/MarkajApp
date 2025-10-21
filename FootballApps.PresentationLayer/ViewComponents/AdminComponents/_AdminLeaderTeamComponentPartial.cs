using FootballApps.DtoLayer.Dtos.TeamDtos;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FootballApps.PresentationLayer.ViewComponents.AdminComponents
{
    public class _AdminLeaderTeamComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminLeaderTeamComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7165/api/Teams/GetMaxPointByTeam");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTeamDto>>(jsonData);
            return View(values);
        }
    }
}
