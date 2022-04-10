
namespace LosBarriosDomain.Models;

public interface ISpeakerHelper
{
    public string GetFirstName(string FirstName);
    public string GetLastName(string LastName);
    public string GetEmailAddrress(string Email);


    public string  GetJobTitle(string JobTitle);
    public Employer GetEmployer(Employer Employer);
    public string GetAddress(string Address);
    public string GetBusinessPhone(string BusinessPhone);
    public string GetCellPhone(string CellPhone);
    public int GetLunchCount(int LunchCount);
    public string GetDemonstration(string Demonstration);
    public string GetTopicTitle(string TopicTitle);
    public string GetTopicDes(string TopicDes);
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
        return LastName;
    }
    public string GetEmailAddrress(string Email)
    {
        return Email;
    }
    public string GetJobTitle(string Jobtitle)
    {
        return Jobtitle;
    }
    public Employer GetEmployer(Employer Employer)
    {
        return Employer;
    }
    public string GetAddress(string Address)
    {
        return Address;
    }
    public string GetBusinessPhone(string BusinessPhone)
    {
        return BusinessPhone;
    }
    public string GetCellPhone(string CellPhone)
    {
        return CellPhone;
    }
    public int GetLunchCount(int LunchCount)
    {
        return LunchCount;
    }
    public string GetDemonstration(string Demonstration)
    {
        return Demonstration;
    }
    public string GetTopicTitle(string TopicTitle)
    {
        return TopicTitle;
    }
    public string GetTopicDes(string TopicDes)
    {
        return TopicDes;
    }
}

