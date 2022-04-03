using SendGrid;
using SendGrid.Helpers.Mail;
using webapp.Services; 
using emaillib;
namespace webapp.Services;



public class AuthMessageSenderOptions
{
    public string? SendGridKey { get; set; }
    public string? SENDGRID_API_KEY { get; set; }
    public string? EMAIL_FROM_ADDRESS { get; set; }
    
}



// public class AuthMessageSenderOptions
// {
//     public string? SENDGRID_API_KEY { get; set; }
//     public string? EMAIL_FROM_ADDRESS { get; set; }
// }

