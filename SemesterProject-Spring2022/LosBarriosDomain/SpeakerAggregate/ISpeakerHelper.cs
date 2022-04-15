namespace LosBarriosDomain.SpeakerAggregate;

public interface ISpeakerHelper
{
    public string ValidateFirstName(string FirstName);
    public string ValidateLastName(string LastName);
    public string ValidateEmailAddress(string Email);
    public string  ValidateJobTitle(string JobTitle);
    public string ValidateEmployer(string Employer);
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
        if(FirstName.Length == 0){
            throw new ArgumentException("Cannot be 0 characters");
        }
        if(FirstName == null)
        {
            throw new ArgumentException("Cannot be null");
        }
        return FirstName;
    }
    public string ValidateLastName(string LastName)
    {
        if(LastName.Length == 0){
            throw new ArgumentException("Cannot be 0 characters");
        }
        if(LastName == null)
        {
            throw new ArgumentException("Cannot be null");
        }
        return LastName;
    }
    public string ValidateEmailAddress(string Email)
    {
        if(Email == null)
        {
            throw new ArgumentException("Cannot be null");
        }
        // if (Email !=){} ///Needs to check if email being inputed is the same as identity Email that is used to login.
        return Email;
    }
    public string ValidateJobTitle(string JobTitle)
    {
        if(JobTitle.Length == 0){
            throw new ArgumentException("Cannot be 0 characters");
        }
        if(JobTitle == null)
        {
            throw new ArgumentException("Cannot be null");
        }
        return JobTitle;
    }
    public string ValidateEmployer(string Employer)
    {
        if(Employer == null)
        {
            throw new ArgumentException("Cannot be null");
        }
        if(Employer.Length == 0){
            throw new ArgumentException("Cannot be 0 characters");
        }
        return Employer;
    }

    public string ValidateAddress(string Address)
    {
        if(Address.Length == 0){
            throw new ArgumentException("Cannot be 0 characters");
        }
        if(Address == null)
        {
            throw new ArgumentException("Cannot be null");
        }
        return Address;
    }
    public string ValidateBusinessPhone(string BusinessPhone)
    {
        if(BusinessPhone.Length < 10){
            throw new ArgumentException("Cannot be less than 10 characters");
        }
        if(BusinessPhone == null)
        {
            throw new ArgumentException("Cannot be null");
        }
        return BusinessPhone;
    }
    public string ValidateCellPhone(string CellPhone)
    {
        if(CellPhone.Length < 10){
            throw new ArgumentException("Cannot be less than 10 characters");
        }
        if(CellPhone == null)
        {
            throw new ArgumentException("Cannot be null");
        }
        return CellPhone;
    }
    public int ValidateLunchCount(int LunchCount)
    {
        if(LunchCount < 0)
        {
            throw new ArgumentException("Cannot be 0 characters");
        }
        if(LunchCount > 10)
        {
            throw new ArgumentException("Cannot have more than 10 friends. Impossible.");
        }
        return LunchCount;
    }
    public string ValidateDemonstration(string Demonstration)
    {
        if(Demonstration.Length == 0){
            throw new ArgumentException("Cannot be 0 characters");
        }
        if(Demonstration == null)
        {
            throw new ArgumentException("Cannot be null");
        }
        return Demonstration;
    }
    public string ValidateTopicTitle(string TopicTitle)
    {
        if(TopicTitle.Length == 0){
            throw new ArgumentException("Cannot be 0 characters");
        }
        if(TopicTitle == null)
        {
            throw new ArgumentException("Cannot be null");
        }
        return TopicTitle;
    }
    public string ValidateTopicDes(string TopicDes)
    {
        if(TopicDes.Length == 0){
            throw new ArgumentException("Cannot be 0 characters");
        }
        if(TopicDes == null)
        {
            throw new ArgumentException("Cannot be null");
        }
        return TopicDes;
    }
}

