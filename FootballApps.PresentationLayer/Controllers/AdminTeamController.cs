using FootballApps.DtoLayer.Dtos.TeamDtos;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.PresentationLayer.Controllers
{
    public class AdminTeamController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminTeamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7165/api/Teams/{id}");
            var json = await response.Content.ReadAsStringAsync();
            var Team = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateTeamDto>(json);
            return View(Team); // Güncelleme formunu göster
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTeamDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7165/api/Teams", content);

            TempData["Message"] = response.IsSuccessStatusCode ? "Team güncellendi." : "Hata oluştu.";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7165/api/Teams/{id}");
            TempData["Message"] = response.IsSuccessStatusCode ? "Team silindi." : "Hata oluştu.";
            return RedirectToAction("Index");
        }
    }
}
