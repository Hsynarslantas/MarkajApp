using System.Text;
using System.Text.Json;
using FootballApps.DtoLayer.Dtos.AIDtos;

namespace FootballApps.PresentationLayer.Services.GeminiService
{
    public class GeminiCommentService
    {
        private readonly HttpClient _httpClient;
        private readonly MailService _mailService;

        public GeminiCommentService(HttpClient httpClient, MailService mailService)
        {
            _httpClient = httpClient;
            _mailService = mailService;
        }

        public async Task<string> GenerateReplyAsync(string userMessage, string userEmail)
        {
            var requestUrl = "https://gemini-pro-ai.p.rapidapi.com/";
            var apiKey = "***********************";

            var prompt = "Sen MarkajApp sitesinin futbol bölümü için özel olarak tasarlanmış bir yapay zekasın. "
           + "Cevapların samimi, kullanıcı dostu, futbol sitesi sahibi tonunda ve siteyi temsil ediyormuş gibi olmalı. "
           + "Kesinlikle resmi kurum dili kullanma.\n\n"
           + "Kullanıcının mesajı: " + userMessage;

            var requestBody = new
            {
                contents = new[]
                {
        new
        {
            role = "user",
            parts = new[]
            {
                new { text = prompt }
            }
        }
    }
            };



            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            request.Headers.Add("x-rapidapi-key", apiKey);
            request.Headers.Add("x-rapidapi-host", "gemini-pro-ai.p.rapidapi.com");
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<GeminiCommentDto.Rootobject>(responseJson);

            // Gemini cevabını al
            var reply = result?.candidates?.FirstOrDefault()?.content?.parts?.FirstOrDefault()?.text
                        ?? "Teşekkür ederiz.";

            // ✉️ Kullanıcıya mail gönder
            if (!string.IsNullOrEmpty(userEmail))
            {
                string subject = "Yorumunuza Cevap";
                string body = reply;
                await _mailService.SendEmailAsync(userEmail, subject, body);
            }

            return reply;
        }
    }
}
