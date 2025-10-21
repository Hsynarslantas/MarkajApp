using System.Net.Mail;
using System.Net;

namespace FootballApps.PresentationLayer.Services.GeminiService
{
    public class MailService
    {
        private readonly string _smtpHost = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _senderEmail = "****************";
        private readonly string _senderPassword = "****************";

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using (var client = new SmtpClient(_smtpHost, _smtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(_senderEmail, _senderPassword);

                var mailMessage = new MailMessage(_senderEmail, to, subject, body);
                mailMessage.IsBodyHtml = false;

                try
                {
                    Console.WriteLine("📨 Mail gönderiliyor...");
                    await client.SendMailAsync(mailMessage);
                    Console.WriteLine("✅ Mail gönderildi!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ SMTP HATASI: {ex.Message}");
                    throw; // üst tarafa da hata gitsin
                }
            }
        }

    }
}
