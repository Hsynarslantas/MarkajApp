
using System.Net.Http;
using System.Text;
using FootballApps.DtoLayer.Dtos.MatchsDtos;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.PresentationLayer.Controllers
{
    public class AdminMatchController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminMatchController(IHttpClientFactory httpClientFactory)
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
            var response = await client.GetAsync($"https://localhost:7165/api/Matchs/{id}");
            var json = await response.Content.ReadAsStringAsync();
            var Match = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateMatchDto>(json);
            return View(Match); // Güncelleme formunu göster
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMatchDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7165/api/Matchs", content);

            TempData["Message"] = response.IsSuccessStatusCode ? "Match güncellendi." : "Hata oluştu.";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7165/api/Matchs/{id}");
            TempData["Message"] = response.IsSuccessStatusCode ? "Match silindi." : "Hata oluştu.";
            return RedirectToAction("Index");
        }
    }
}
