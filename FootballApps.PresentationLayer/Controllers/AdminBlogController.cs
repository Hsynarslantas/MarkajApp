using FootballApps.DtoLayer.Dtos.BlogDtos;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.PresentationLayer.Controllers
{
    public class AdminBlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBlogController(IHttpClientFactory httpClientFactory)
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
            var response = await client.GetAsync($"https://localhost:7165/api/Blogs/{id}");
            var json = await response.Content.ReadAsStringAsync();
            var blog = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateBlogDto>(json);
            return View(blog); // Güncelleme formunu göster
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7165/api/Blogs", content);

            TempData["Message"] = response.IsSuccessStatusCode ? "Blog güncellendi." : "Hata oluştu.";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7165/api/Blogs/{id}");
            TempData["Message"] = response.IsSuccessStatusCode ? "Blog silindi." : "Hata oluştu.";
            return RedirectToAction("Index");
        }
    }
}
