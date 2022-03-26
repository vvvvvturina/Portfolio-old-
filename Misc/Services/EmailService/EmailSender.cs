using MimeKit;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Tls;
using Portfolio.Misc.Services.EmailService;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Misc.Services.EmailService;

public class EmailSender : IEmailSender
{
    private readonly EmailConfiguration _emailConfig;

    private readonly ILogger<EmailSender> _logger;
    public EmailSender(ILogger<EmailSender> logger, EmailConfiguration emailConfig)
    {
        _emailConfig = emailConfig;
        _logger = logger;
    }

    public void SendEmail(string messageBody)
    {
        var message = CreateEmailMessage(messageBody.ToString());
        try
        {
            using (SmtpClient client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("mail@gmail.com", "pass");
                client.Send(message);
                
                client.Disconnect(true);
                _logger.LogInformation("message sent successfully");
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e.GetBaseException().Message);
        }
    }
    

    public MimeMessage CreateEmailMessage(string mesBody)
    {
        MimeMessage message = new MimeMessage();
        message.From.Add(new MailboxAddress("mail@gmail.com","mail@gmail.com"));
        message.To.Add(new MailboxAddress("vltr", "receiver@gmail.com"));
        message.Subject = "new message using mailkil";
        message.Body = new BodyBuilder() {HtmlBody = $"<div style=\"color: green;\">{mesBody}</div>"}.ToMessageBody();
        return message;
    }
}
