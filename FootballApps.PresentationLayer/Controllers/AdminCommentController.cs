using FootballApps.DtoLayer.Dtos.CommentDtos;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace FootballApps.PresentationLayer.Controllers
{
    public class AdminCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCommentController(IHttpClientFactory httpClientFactory)
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
            var response = await client.GetAsync($"https://localhost:7165/api/Comments/{id}");
            var json = await response.Content.ReadAsStringAsync();
            var Comment = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateCommentDto>(json);
            return View(Comment);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCommentDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7165/api/Comments", content);

            TempData["Message"] = response.IsSuccessStatusCode ? "Comment güncellendi." : "Hata oluştu.";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7165/api/Comments/{id}");
            TempData["Message"] = response.IsSuccessStatusCode ? "Comment silindi." : "Hata oluştu.";
            return RedirectToAction("Index");
        }
    }
}
