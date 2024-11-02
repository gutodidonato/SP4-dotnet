using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

public class EmailService
{
    private readonly string _apiKey;

    public EmailService(string apiKey)
    {
        _apiKey = "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";
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var client = new SendGridClient(_apiKey);
        var from = new EmailAddress("gutodidonato@gmail.com", "Janos Enterprise");
        var to = new EmailAddress(toEmail);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
        var response = await client.SendEmailAsync(msg);
        
        if (!response.IsSuccessStatusCode)
        {
           var responseBody = await response.Body.ReadAsStringAsync();
        }
    }
}
