using FootballApps.DtoLayer.Dtos.CommentDtos;
using FootballApps.PresentationLayer.Services.GeminiService;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FootballApps.DtoLayer.Dtos.ContactCommentDtos;

namespace FootballApps.PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly GeminiCommentService _geminiCommentService;

        public ContactController(IHttpClientFactory httpClientFactory, GeminiCommentService geminiCommentService)
        {
            _httpClientFactory = httpClientFactory;
            _geminiCommentService = geminiCommentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactCommentDto dto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7165/api/ContactComments", content);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // 💬 Yorum başarılıysa AI'den cevap al ve kullanıcıya mail at
                    await _geminiCommentService.GenerateReplyAsync(dto.Message, dto.Email);

                    TempData["Message"] = "Yorum başarıyla gönderildi ve AI cevabı e-posta adresine gönderildi. ✅";
                }
                else
                {
                    TempData["Message"] = $"API Hatası: {response.StatusCode} - {responseBody} ❌";
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"HATA: {ex.Message} ❌";
            }

            return RedirectToAction("Index", "Contact");
        }
    }
}
