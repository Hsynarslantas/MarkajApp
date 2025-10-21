using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using FootballApps.DtoLayer.Dtos.MatchsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FootballApps.PresentationLayer.ViewComponents.MatchComponents
{
    public class _DefaultMatchComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultMatchComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await  client.GetAsync("https://localhost:7165/api/Matchs/GetListWithTeams");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultsMatchDto>>(jsonData);
            return View(values);
        }
    }
}
