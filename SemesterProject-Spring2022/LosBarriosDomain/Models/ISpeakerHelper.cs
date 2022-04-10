
namespace LosBarriosDomain.Models;

public interface ISpeakerHelper
{
    public string GetFirstName(string FirstName);
    public string GetLastName(string LastName);
    public string GetEmailAddrress(string Email);
}

public class MySpeakerHelper : ISpeakerHelper
{
    public string GetFirstName(string FirstName)
    {
        // TODO: validation steps
        return FirstName;
    }
    public string GetLastName(string LastName)
    {
        return string.Empty;
    }
    public string GetEmailAddrress(string Email)
    {
        return Email;
    }
}

