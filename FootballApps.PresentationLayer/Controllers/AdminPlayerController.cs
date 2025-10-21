using FootballApps.DtoLayer.Dtos.PlayerDtos;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.PresentationLayer.Controllers
{
    public class AdminPlayerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminPlayerController(IHttpClientFactory httpClientFactory)
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
            var response = await client.GetAsync($"https://localhost:7165/api/Players/{id}");
            var json = await response.Content.ReadAsStringAsync();
            var Player = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdatePlayerDto>(json);
            return View(Player); 
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePlayerDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7165/api/Players", content);

            TempData["Message"] = response.IsSuccessStatusCode ? "Player güncellendi." : "Hata oluştu.";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7165/api/Players/{id}");
            TempData["Message"] = response.IsSuccessStatusCode ? "Player silindi." : "Hata oluştu.";
            return RedirectToAction("Index");
        }
    }
}
