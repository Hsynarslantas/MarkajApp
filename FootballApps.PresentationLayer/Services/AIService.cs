using Newtonsoft.Json.Linq;
using System.Text;

namespace FootballApps.PresentationLayer.Services
{
    public class AIService
    {
        private readonly HttpClient _client;

        public AIService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("x-rapidapi-key", "*************************");
            _client.DefaultRequestHeaders.Add("x-rapidapi-host", "chatgpt-42.p.rapidapi.com");
        }

        public async Task<string> GetChatReplyAsync(string userMessage)
        {
            var requestBody = $@"{{
            ""messages"": [
                {{
                    ""role"": ""system"", 
                    ""content"": ""Sen profesyonel bir futbol analisti ve tahmin uzmanısın. Kullanıcının sorduğu maç için aşağıdaki kriterlere göre detaylı ve somut bir tahmin yap:\n\n1. Her iki takımın son 5 maçtaki formunu değerlendir\n2. İç saha/deplasman avantajını göz önünde bulundur\n3. Takımlar arası geçmiş maç istatistiklerini dikkate al\n4. Olası skor tahmini ver (örn: 2-1, 1-1, 3-0)\n5. Maç sonucu tahmini (Ev Sahibi Galip, Beraberlik, Deplasman Galip)\n6. Alt/Üst 2.5 gol tahmini\n7. İki takım da gol atar mı tahmini\n8. Tahminin güven yüzdesini belirt (%60, %75 gibi)\n\nCevabını yapılandırılmış ve net bir şekilde ver. Genel laflar yerine somut tahminler sun.""
                }},
                {{
                    ""role"": ""user"", 
                    ""content"": ""{userMessage}""
                }}
            ],
            ""model"": ""gpt-4o-mini"",
            ""temperature"": 0.7,
            ""max_tokens"": 800
        }}";

            var request = new HttpRequestMessage(HttpMethod.Post, "https://chatgpt-42.p.rapidapi.com/chat")
            {
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };

            try
            {
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();

                // JSON içinden cevabı çekelim
                var json = JObject.Parse(jsonString);
                var reply = json["choices"]?[0]?["message"]?["content"]?.ToString();

                return reply ?? "Bir hata oluştu, cevap alınamadı.";
            }
            catch (Exception ex)
            {
                return $"Tahmin alınırken bir hata oluştu: {ex.Message}";
            }
        }
    }
}
