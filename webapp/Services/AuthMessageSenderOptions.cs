/*using SendGrid;
using SendGrid.Helpers.Mail;
using webapp.Services; 

namespace webapp.Services;
public class AuthMessageSenderOptions
{
    public string? SendGridKey { get; set; }
    
}*/

namespace webapp.Services;

public class AuthMessageSenderOptions
{
    public string? SENDGRID_API_KEY { get; set; }
    public string? EMAIL_FROM_ADDRESS { get; set; }
}

