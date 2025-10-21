using FootballApps.DtoLayer.Dtos.BlogDtos;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using FootballApps.DtoLayer.Dtos.TeamDtos;

namespace FootballApps.PresentationLayer.ViewComponents.AdminComponents
{
    public class _AdminTeamListComponentPartial:ViewComponent
    {
        private readonly  IHttpClientFactory _httpClientFactory;

        public _AdminTeamListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7165/api/Teams");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTeamDto>>(jsonData);
            return View(values);
        }
    }
}
