
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
        if(FirstName == null)
        {
            throw new ArgumentException();
        }
        return FirstName;
    }
    public string GetLastName(string LastName)
    {
        if(LastName == null)
        {
            throw new ArgumentException();
        }
        return LastName;
    }
    public string GetEmailAddrress(string Email)
    {
        if(Email == null)
        {
            throw new ArgumentException();
        }
        return Email;
    }
    public string GetJobTitle(string Jobtitle)
    {
        if(Jobtitle == null)
        {
            throw new ArgumentException();
        }
        return Jobtitle;
    }
    public Employer GetEmployer(Employer Employer)
    {
        if(Employer == null)
        {
            throw new ArgumentException();
        }
        return Employer;
    }
    public string GetAddress(string Address)
    {
        if(Address == null)
        {
            throw new ArgumentException();
        }
        return Address;
    }
    public string GetBusinessPhone(string BusinessPhone)
    {
        if(BusinessPhone == null)
        {
            throw new ArgumentException();
        }if(BusinessPhone.Length <= 10)
        {
            throw new ArgumentException();
        }
        return BusinessPhone;
    }
    public string GetCellPhone(string CellPhone)
    {
        if(CellPhone == null)
        {
            throw new ArgumentException();
        }
        if(CellPhone.Length <= 10)
        {
            throw new ArgumentException();
        }
        return CellPhone;
    }
    public int GetLunchCount(int LunchCount)
    {
        if(LunchCount < 0)
        {
            throw new ArgumentException();
        }
        return LunchCount;
    }
    public string GetDemonstration(string Demonstration)
    {
        if(Demonstration == null)
        {
            throw new ArgumentException();
        }
        return Demonstration;
    }
    public string GetTopicTitle(string TopicTitle)
    {
        if(TopicTitle == null)
        {
            throw new ArgumentException();
        }
        return TopicTitle;
    }
    public string GetTopicDes(string TopicDes)
    {
        if(TopicDes == null)
        {
            throw new ArgumentException();
        }
        return TopicDes;
    }
    // Speaker speaker = new Speaker {FirstName = GetFirstName(string FirstName)};
}

