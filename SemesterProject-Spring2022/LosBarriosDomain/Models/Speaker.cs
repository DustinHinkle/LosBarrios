#nullable disable
namespace LosBarriosDomain.Models;
public class Speaker
{    
    public int SpeakerId {get; set;} //Primary key
    // Name: Click here to enter text
    // https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress?view=net-6.0
    public string Email { get; set; } = string.Empty;
    public string FirstName {get; set; } = string.Empty;
    public string LastName {get; set; } = string.Empty;
    // Place of employment and job title:  Click here to enter text
    public string JobTitle { get; set; } = string.Empty;
    public Employer Employer {get; set; } = null;
    // Mailing address: Click here to enter text   
    public string Address {get; set; } = string.Empty;
    // Business & cell phone #’s: Click here to enter text	
    public string CellPhone { get; set; } = string.Empty;
    public string BusinessPhone { get; set; } = string.Empty;

    // Please briefly describe the activity/demonstration planned for your session: Click here to enter text 
    public string Demonstration {get; set;} = string.Empty;
    // How many in your group will be joining us for lunch? (# needed for lunch count) Click here to enter text    
    public int LunchCount {get; set;} 
    public string TopicTitle {get;set;}=string.Empty;
    public string TopicDes {get;set;} = string.Empty;

}