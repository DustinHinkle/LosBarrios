/*using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace webapp.Services;

public class EmailSender : IEmailSender
{
    private readonly ILogger _logger;

    public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                       ILogger<EmailSender> logger)
    {
        Options = optionsAccessor.Value;
        _logger = logger;
    }

    public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(Options.SendGridKey))
        {
            throw new Exception("Null SendGridKey");
        }
        await Execute(Options.SendGridKey, subject, message, toEmail);
    }

    public async Task Execute(string apiKey, string subject, string message, string toEmail)
    {
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("Joe@contoso.com", "Password Recovery"),
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = message
        };
        msg.AddTo(new EmailAddress(toEmail));

        // Disable click tracking.
        // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
        msg.SetClickTracking(false, false);
        var response = await client.SendEmailAsync(msg);
        _logger.LogInformation(response.IsSuccessStatusCode 
                               ? $"Email to {toEmail} queued successfully!"
                               : $"Failure Email to {toEmail}");
    }
}*/
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

using webapp;


namespace webapp.Services;

public class EmailSender : IEmailSender
{
    private readonly ILogger _logger;
    private  EmailSenderAdapter SenderAdapter {get; } = new EmailSenderAdapter();

    public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                       ILogger<EmailSender> logger)
    {
        Options = optionsAccessor.Value;
        _logger = logger;
    }

    public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(Options.SENDGRID_API_KEY))
        {
            throw new Exception("Null SendGridKey");
        }
        _logger.LogInformation("SENDGRID_API_KEY OK");

        if (string.IsNullOrEmpty(Options.EMAIL_FROM_ADDRESS))
        {
            throw new Exception("Null SendGridKey");
        }        
        _logger.LogInformation("EMAIL_FROM_ADDRESS OK");

        // this calls our seperate service
        await SenderAdapter.SendEmailAsync(
            Options.SENDGRID_API_KEY, 
            subject, 
            message, 
            toEmail, 
            Options.EMAIL_FROM_ADDRESS);
    }
    
}
