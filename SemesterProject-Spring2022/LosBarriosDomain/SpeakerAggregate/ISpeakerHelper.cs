
namespace LosBarriosDomain.SpeakerAggregate;

public interface ISpeakerHelper
{
    public string ValidateFirstName(string FirstName);
    public string ValidateLastName(string LastName);
    public string ValidateEmailAddrress(string Email);
    public string  ValidateJobTitle(string JobTitle);
    public string ValidateAddress(string Address);
    public string ValidateCellPhone(string CellPhone);
    public string ValidateBusinessPhone(string BusinessPhone);
    public int ValidateLunchCount(int LunchCount);
    public string ValidateDemonstration(string Demonstration);
    public string ValidateTopicTitle(string TopicTitle);
    public string ValidateTopicDes(string TopicDes);
}
	
public class MySpeakerHelper : ISpeakerHelper
{
    public string ValidateFirstName(string FirstName)
    {
        // TODO: validation steps
        if(FirstName.Length ==0){
            throw new ArgumentException();
        }
        if(FirstName ==null)
        {
            throw new ArgumentException();
        }
        return FirstName;
    }
    public string ValidateLastName(string LastName)
    {
        if(LastName.Length ==0){
            throw new ArgumentException();
        }
        if(LastName ==null)
        {
            throw new ArgumentException();
        }
        return LastName;
    }
    public string ValidateEmailAddrress(string Email)
    {
        return Email;
    }
    public string ValidateJobTitle(string JobTitle)
    {
        if(JobTitle.Length ==0){
            throw new ArgumentException();
        }
        if(JobTitle ==null)
        {
            throw new ArgumentException();
        }
        return JobTitle;
    }

    public string ValidateAddress(string Address)
    {
        if(Address.Length ==0){
            throw new ArgumentException();
        }
        if(Address ==null)
        {
            throw new ArgumentException();
        }
        return Address;
    }
    public string ValidateBusinessPhone(string BusinessPhone)
    {
        if(BusinessPhone.Length < 10){
            throw new ArgumentException();
        }
        if(BusinessPhone ==null)
        {
            throw new ArgumentException();
        }
        return BusinessPhone;
    }
    public string ValidateCellPhone(string CellPhone)
    {
        if(CellPhone.Length < 10){
            throw new ArgumentException();
        }
        if(CellPhone ==null)
        {
            throw new ArgumentException();
        }
        return CellPhone;
    }
    public int ValidateLunchCount(int LunchCount)
    {
        if(LunchCount < 0)
        {
            throw new ArgumentException();
        }
        return LunchCount;
    }
    public string ValidateDemonstration(string Demonstration)
    {
        if(Demonstration.Length ==0){
            throw new ArgumentException();
        }
        if(Demonstration ==null)
        {
            throw new ArgumentException();
        }
        return Demonstration;
    }
    public string ValidateTopicTitle(string TopicTitle)
    {
        if(TopicTitle.Length ==0){
            throw new ArgumentException();
        }
        if(TopicTitle ==null)
        {
            throw new ArgumentException();
        }
        return TopicTitle;
    }
    public string ValidateTopicDes(string TopicDes)
    {
        if(TopicDes.Length ==0){
            throw new ArgumentException();
        }
        if(TopicDes ==null)
        {
            throw new ArgumentException();
        }
        return TopicDes;
    }
}

