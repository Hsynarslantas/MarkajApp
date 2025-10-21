using FootballApps.DtoLayer.Dtos.CommentDtos;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FootballApps.PresentationLayer.ViewComponents.CommentComponents
{
    public class _BlogDetailCommentListComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailCommentListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            System.Diagnostics.Debug.WriteLine($"🔍 BlogId alındı: {blogId}");

            try
            {
                var client = _httpClientFactory.CreateClient();
                var url = $"https://localhost:7165/api/Comments/GetCommentsByBlogId/{blogId}";

                System.Diagnostics.Debug.WriteLine($"🌐 API URL: {url}");

                var response = await client.GetAsync(url);

                System.Diagnostics.Debug.WriteLine($"📡 Response Status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"API Hatası: {response.StatusCode}";
                    return View(new List<ResultCommentDto>());
                }

                var json = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"📝 JSON Response: {json}");

                var root = JObject.Parse(json);
                var values = root["$values"]?.ToObject<List<ResultCommentDto>>() ?? new List<ResultCommentDto>();

                System.Diagnostics.Debug.WriteLine($"✅ Yorum sayısı: {values.Count}");

                return View(values);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ HATA: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"❌ Stack Trace: {ex.StackTrace}");
                ViewBag.ErrorMessage = $"Hata: {ex.Message}";
                return View(new List<ResultCommentDto>());
            }
        }
    }
}

